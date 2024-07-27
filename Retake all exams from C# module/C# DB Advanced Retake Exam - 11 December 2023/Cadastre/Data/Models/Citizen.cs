using System.ComponentModel.DataAnnotations;
using Cadastre.Data.Enumerations;

namespace Cadastre.Data.Models;

public class Citizen
{
    public Citizen()
    {
        PropertiesCitizens = new List<PropertyCitizen>();
    }

    [Key] public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    [MinLength(2)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(30)]
    [MinLength(2)]
    public string LastName { get; set; } = null!;

    [Required] public DateTime BirthDate { get; set; }

    [Required] public MaritalStatus MaritalStatus { get; set; }

    public virtual ICollection<PropertyCitizen> PropertiesCitizens { get; set; }
}