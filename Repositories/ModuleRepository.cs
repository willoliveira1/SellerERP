using Microsoft.EntityFrameworkCore;
using SellerERP.Data;
using SellerERP.Models;
using SellerERP.Repositories.Interfaces;

namespace SellerERP.Repositories;

public class ModuleRepository : IModuleRepository
{
    private readonly SellerERPContext _context;

    public ModuleRepository(SellerERPContext context)
    {
        _context = context;
    }

    public void Add(Module module)
    {
        if (module == null)
        {
            throw new ArgumentNullException(nameof(module));
        }
        _context.Modules.Add(module);
    }

    public void Delete(Module module)
    {
        if (module == null)
        {
            throw new ArgumentNullException(nameof(module));
        }
        _context.Modules.Remove(module);
    }

    public void Edit(Module module)
    {
    }

    public IEnumerable<Module> GetAllItems()
    {
        return _context.Modules.ToList();
    }

    public Module GetItemById(int id)
    {
        var modules = _context.Modules.ToList();

        return _context.Modules.FirstOrDefault(m => m.Id == id);
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
}