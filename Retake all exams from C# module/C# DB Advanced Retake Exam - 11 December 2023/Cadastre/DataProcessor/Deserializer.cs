using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using Cadastre.Data;
using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using Cadastre.DataProcessor.ImportDtos;
using Newtonsoft.Json;

namespace Cadastre.DataProcessor;

public class Deserializer
{
    private const string ErrorMessage =
        "Invalid Data!";

    private const string SuccessfullyImportedDistrict =
        "Successfully imported district - {0} with {1} properties.";

    private const string SuccessfullyImportedCitizen =
        "Succefully imported citizen - {0} {1} with {2} properties.";

    public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
    {
        var sb = new StringBuilder();
        var serializer = new XmlSerializer(typeof(ImportDistrictDTO[]), new XmlRootAttribute("Districts"));
        using var reader = new StringReader(xmlDocument);

        var districtDTOs = (ImportDistrictDTO[])serializer.Deserialize(reader);
        var districts = new List<District>();

        foreach (var dDTO in districtDTOs)
        {
            if (!IsValid(dDTO))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (dbContext.Districts.Any(d => d.Name == dDTO.Name))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            var district = new District
            {
                Region = dDTO.Region,
                Name = dDTO.Name,
                PostalCode = dDTO.PostalCode
            };

            foreach (var pDTO in dDTO.Properties)
            {
                if (!IsValid(pDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (dbContext.Properties.Any(p => p.PropertyIdentifier == pDTO.PropertyIdentifier) ||
                    district.Properties.Any(dp => dp.PropertyIdentifier == pDTO.PropertyIdentifier))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (dbContext.Properties.Any(p => p.Address == pDTO.Address) ||
                    district.Properties.Any(dp => dp.Address == pDTO.Address))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime dateOfAcquisition;
                var isDateOfAcquisition = DateTime
                    .TryParseExact(pDTO.DateOfAcquisition, "dd/MM/yyyy", CultureInfo
                        .InvariantCulture, DateTimeStyles.None, out dateOfAcquisition);

                if (!isDateOfAcquisition)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var property = new Property
                {
                    PropertyIdentifier = pDTO.PropertyIdentifier,
                    Area = pDTO.Area,
                    Details = pDTO.Details,
                    Address = pDTO.Address,
                    DateOfAcquisition = dateOfAcquisition
                };

                district.Properties.Add(property);
            }

            districts.Add(district);
            sb.AppendLine(string.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count));
        }

        dbContext.AddRange(districts);
        dbContext.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
    {
        var sb = new StringBuilder();
        var validCitizens = new List<Citizen>();


        var citizensDTO = JsonConvert.DeserializeObject<ImportCitizenDTO[]>(jsonDocument);

        foreach (var cDTO in citizensDTO)
        {
            if (!IsValid(cDTO))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            DateTime birthDate;
            var isBirthDateValid = DateTime
                .TryParseExact(cDTO.BirthDate, "dd-MM-yyyy", CultureInfo
                    .InvariantCulture, DateTimeStyles.None, out birthDate);

            if (!isBirthDateValid)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            var citizen = new Citizen
            {
                FirstName = cDTO.FirstName,
                LastName = cDTO.LastName,
                BirthDate = birthDate,
                MaritalStatus = (MaritalStatus)Enum.Parse(typeof(MaritalStatus), cDTO.MaritalStatus)
            };

            foreach (var pId in cDTO.Properties)
            {
                var pc = new PropertyCitizen
                {
                    Citizen = citizen,
                    PropertyId = pId
                };

                citizen.PropertiesCitizens.Add(pc);
            }

            validCitizens.Add(citizen);
            sb.AppendLine(string.Format(SuccessfullyImportedCitizen,
                citizen.FirstName, citizen.LastName, citizen.PropertiesCitizens.Count));
        }

        dbContext.Citizens.AddRange(validCitizens);
        dbContext.SaveChanges();

        return sb.ToString().TrimEnd();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }
}