using System.ComponentModel.DataAnnotations;

namespace SellerERP.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    public virtual ICollection<Module> Modules { get; set; }
}