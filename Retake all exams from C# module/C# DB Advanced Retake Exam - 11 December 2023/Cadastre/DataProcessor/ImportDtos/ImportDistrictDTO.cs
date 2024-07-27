using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Cadastre.Data.Enumerations;

namespace Cadastre.DataProcessor.ImportDtos;

[XmlType("District")]
public class ImportDistrictDTO
{
    [XmlElement("Name")]
    [MinLength(2)]
    [MaxLength(80)]
    [Required]
    public string Name { get; set; } = null!;

    [XmlAttribute("Region")] [Required] public Region Region { get; set; }

    [XmlElement("PostalCode")]
    [Required]
    [MaxLength(8)]
    [MinLength(8)]
    [RegularExpression(@"^[A-Z]{2}-\d{5}$")]
    public string PostalCode { get; set; } = null!;

    [XmlArray("Properties")] public ImportPropertyDTO[] Properties { get; set; }
}