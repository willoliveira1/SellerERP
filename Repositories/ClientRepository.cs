using SellerERP.Data;
using SellerERP.Models;
using SellerERP.Repositories.Interfaces;

namespace SellerERP.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly SellerERPContext _context;

    public ClientRepository(SellerERPContext context)
    {
        _context = context;
    }

    public void Add(Client client)
    {
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client));
        }
        _context.Clients.Add(client);
    }

    public void Delete(Client client)
    {
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client));
        }
        _context.Clients.Remove(client);
    }

    public void Edit(Client client)
    {
    }

    public IEnumerable<Client> GetAllItems()
    {
        return _context.Clients.ToList();
    }

    public Client GetItemById(int id)
    {
        return _context.Clients.FirstOrDefault(c => c.Id == id);
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
}