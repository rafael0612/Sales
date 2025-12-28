using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities;

public class Country
{
    [Key]
    public int CountryId { get; set; }
    [Required]
    public string Name { get; set; } = null!;
}
