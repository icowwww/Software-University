using System.Text;
using System.Xml.Serialization;
using Cadastre.Data;
using Cadastre.DataProcessor.ExportDtos;
using Newtonsoft.Json;

namespace Cadastre.DataProcessor;

public class Serializer
{
    public static string ExportPropertiesWithOwners(CadastreContext dbContext)
    {
        var properties = dbContext.Properties
            .Where(p => p.DateOfAcquisition >= DateTime.Parse("01/01/2000"))
            .OrderByDescending(p => p.DateOfAcquisition)
            .ThenBy(p => p.PropertyIdentifier)
            .Select(p => new
            {
                p.PropertyIdentifier,
                p.Area,
                p.Address,
                DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy"),
                Owners = p.PropertiesCitizens
                    .OrderBy(pc => pc.Citizen.LastName)
                    .Select(pc => new
                    {
                        pc.Citizen.LastName,
                        MaritalStatus = pc.Citizen.MaritalStatus.ToString()
                    })
            })
            .ToArray();

        return JsonConvert.SerializeObject(properties, Formatting.Indented);
    }

    public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
    {
        var sb = new StringBuilder();

        var serializer = new XmlSerializer(typeof(ExportPropertyDTO[]),
            new XmlRootAttribute("Properties"));

        var namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);

        using var writer = new StringWriter(sb);

        var properties = dbContext.Properties
            .Where(p => p.Area >= 100)
            .OrderByDescending(p => p.Area)
            .ThenBy(p => p.DateOfAcquisition)
            .Select(p => new ExportPropertyDTO
            {
                PostalCode = p.District.PostalCode,
                PropertyIdentifier = p.PropertyIdentifier,
                Area = p.Area,
                DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy")
            })
            .ToArray();

        serializer.Serialize(writer, properties, namespaces);

        return sb.ToString().TrimEnd();
    }
}