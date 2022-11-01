using SellerERP.Models;
using System.ComponentModel.DataAnnotations;

namespace SellerERP.Dtos.ProductDto;

public class ProductUpdateDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    public virtual ICollection<Module> Modules { get; set; }
}