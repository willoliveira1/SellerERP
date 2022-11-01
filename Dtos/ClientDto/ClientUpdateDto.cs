using SellerERP.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SellerERP.Dtos.ClientDto;

public class ClientUpdateDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(200)]
    public string Address { get; set; }

    [Required]
    [MaxLength(100)]
    public string InvoiceEmail { get; set; }

    public bool IsActive { get; set; }

    [Required]
    public int ProductId { get; set; }
    [JsonIgnore]
    public Product Product { get; set; }
}