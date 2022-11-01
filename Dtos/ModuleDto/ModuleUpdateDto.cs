using SellerERP.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SellerERP.Dtos.ModuleDto;

public class ModuleUpdateDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public int ProductId { get; set; }

    [JsonIgnore]
    public Product Product { get; set; }
}
