using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace SellerERP.Models;

public class Module
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    public int ProductId { get; set; }

    [JsonIgnore]
    public Product Product { get; set; }
}