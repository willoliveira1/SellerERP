using SellerERP.Models;
using System.Collections.Generic;

namespace SellerERP.Data;

public class SeedingService
{
    private readonly SellerERPContext _context;

    public SeedingService(SellerERPContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        if (_context.Products.Any() || _context.Modules.Any() || _context.Clients.Any())
        {
            return;
        }
        
        var products = new Product[]
        {
            new Product { Name = "ERP" },
            new Product { Name = "BI" }
        };
        _context.Products.AddRange(products);
        _context.SaveChanges();

        var modules = new Module[]
        {
            new Module{ Name = "Supply", ProductId = 1 },
            new Module{ Name = "Human Resources", ProductId = 1 },
            new Module{ Name = "Finance", ProductId = 1 },
            new Module{ Name = "Controlling", ProductId = 1 },
            new Module{ Name = "Tax", ProductId = 1 },
            new Module{ Name = "Quality Assurance", ProductId = 1 },
            new Module{ Name = "Accounting", ProductId = 1 },
            new Module{ Name = "Commercial", ProductId = 1 },
            new Module{ Name = "Planning", ProductId = 1 },
            new Module{ Name = "Financial Reports", ProductId = 2 },
            new Module{ Name = "Commercial Reports", ProductId = 2 },
            new Module{ Name = "Accounting Reports", ProductId = 2 },
            new Module{ Name = "Planning Reports", ProductId = 2 },
        };
        _context.Modules.AddRange(modules);
        _context.SaveChanges();

        var clients = new Client[]
        {
            new Client{ Name = "Star Lines", Address = "Rua 1", InvoiceEmail = "email11@gmail.com", IsActive = true, ProductId = 1 },
            new Client{ Name = "Lines Airlines", Address = "Rua 2", InvoiceEmail = "email22@hotmail.com", IsActive = true, ProductId = 1 },
            new Client{ Name = "Enterprise 3", Address = "Rua 3", InvoiceEmail = "email33@email.com", IsActive = true, ProductId = 2 },
            new Client{ Name = "Enterprise 4", Address = "Rua 4", InvoiceEmail = "email44@email.com", IsActive = true, ProductId = 1 }
        };
        _context.Clients.AddRange(clients);
        _context.SaveChanges();
    }
}