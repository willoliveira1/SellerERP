using SellerERP.Models;
using System.ComponentModel.DataAnnotations;

namespace SellerERP.Dtos.ProductDto;

public class ProductCreateDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    public ICollection<Module> Modules { get; set; }
}