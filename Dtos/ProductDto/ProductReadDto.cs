using SellerERP.Models;

namespace SellerERP.Dtos.ProductDto;

public class ProductReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Module> Modules { get; set; }
}