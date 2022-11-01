using SellerERP.Models;
using System.Text.Json.Serialization;

namespace SellerERP.Dtos.ClientDto;

public class ClientReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string InvoiceEmail { get; set; }
    public bool IsActive { get; set; }
    public int ProductId { get; set; }

    [JsonIgnore]
    public Product Product { get; set; }
}