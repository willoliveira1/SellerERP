using SellerERP.Data;
using SellerERP.Models;
using SellerERP.Repositories.Interfaces;

namespace SellerERP.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly SellerERPContext _context;

    public ProductRepository(SellerERPContext context)
    {
        _context = context;
    }

    public void Add(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        _context.Products.Add(product);
    }

    public void Delete(Product product)
    {
        if (product == null)
        {
            throw new ArgumentNullException(nameof(product));
        }
        _context.Products.Remove(product);
    }

    public void Edit(Product product)
    {
    }

    public IEnumerable<Product> GetAllItems()
    {
        return _context.Products.ToList();
    }

    public Product GetItemById(int id)
    {
        var product = _context.Products
            .FirstOrDefault(p => p.Id == id);

        product.Modules = _context.Modules.Where(m => m.ProductId == id).ToList();

        return product;
    }
    
    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
}