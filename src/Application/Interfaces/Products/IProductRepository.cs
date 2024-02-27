using Domain.Entities;
using Domain.Enums;

namespace Application.Interfaces.Products
{
    public interface IProductRepository
    {
        Product Save(string name, string description);
        List<Product> GetAll();
        Product GetById(int id);
        bool UpdateName(int id, string name);
        bool UpdateDescription(int id, string description);
        bool UpdateStatus(int id, ProductStatus status);
        bool StockEntry(int id, int quantity);
        bool StockIssue(int id, int quantity);
        bool Delete(int id);
    }
}
