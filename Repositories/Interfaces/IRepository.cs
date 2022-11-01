namespace SellerERP.Repositories.Interfaces;

public interface IRepository<T>
{
    IEnumerable<T> GetAllItems();
    T GetItemById(int id);
    void Add(T obj);
    void Edit(T obj);
    void Delete(T obj);
    bool SaveChanges();
}