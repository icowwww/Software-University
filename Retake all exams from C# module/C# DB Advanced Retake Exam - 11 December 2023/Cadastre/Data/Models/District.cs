using System.ComponentModel.DataAnnotations;
using Cadastre.Data.Enumerations;

namespace Cadastre.Data.Models;

public class District
{
    public District()
    {
        Properties = new List<Property>();
    }

    [Key] public int Id { get; set; }

    [Required]
    [MaxLength(80)]
    [MinLength(2)]
    public string Name { get; set; } = null!;

    [Required] public string PostalCode { get; set; } = null!;

    public Region Region { get; set; }

    public virtual ICollection<Property> Properties { get; set; }
}