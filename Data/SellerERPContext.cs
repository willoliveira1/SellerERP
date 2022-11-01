using Microsoft.EntityFrameworkCore;
using SellerERP.Models;

namespace SellerERP.Data;

public class SellerERPContext : DbContext
{
    public SellerERPContext(DbContextOptions<SellerERPContext> options) : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Module> Modules { get; set; }
    public DbSet<Product> Products { get; set; }
}