using System.ComponentModel.DataAnnotations;

namespace Sales.Shared.Entities;

public class Country
{
    [Key]
    public int CountryId { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
}
