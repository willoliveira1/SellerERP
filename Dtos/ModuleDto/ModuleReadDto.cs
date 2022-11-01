using SellerERP.Models;

namespace SellerERP.Dtos.ModuleDto;

public class ModuleReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
}
