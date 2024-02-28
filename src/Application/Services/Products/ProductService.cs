using Domain.Enums;
using Domain.Entities;
using Application.Interfaces.Products;
using System.Xml.Linq;

namespace Application.Services.Products
{
    public class ProductService : IProductRepository
    {
        private Product _product { get; set; }

        public ProductService() => _product = new Product();

        public Product Save(string name, string description)
        {
            _product.SetName(name);
            _product.SetDescription(description);


            DbStaticForTesting.products.Add(_product);

            return _product;
        }

        public List<Product> GetAll()
        {
            return DbStaticForTesting.products;
        }

        public Product GetById(int id)
        {
            Product product = DbStaticForTesting.products.Find(x => x.Id == id);
            return product;
        }

        public bool UpdateName(int id, string name)
        {
            bool result = true;

            DbStaticForTesting.products.Find(x => x.Id == id).SetName(name);

            return result;
        }

        public bool UpdateDescription(int id, string description)
        {
            bool result = true;

            DbStaticForTesting.products.Find(x => x.Id == id).SetDescription(description);

            return result;
        }

        public bool UpdateStatus(int id, ProductStatus status)
        {
            bool result = true;

            DbStaticForTesting.products.Find(x => x.Id == id).SetStatus(status);

            return result;
        }

        public bool StockEntry(int id, int quantity)
        {
            bool result = true;

            DbStaticForTesting.products.Find(x => x.Id == id).SetQuantity(quantity);

            return result;
        }

        public bool StockIssue(int id, int quantity)
        {
            bool result = true;

            DbStaticForTesting.products.Find(x => x.Id == id).SetQuantity(quantity);

            return result;
        }

        public bool Delete(int id)
        {
            bool result = true;

            DbStaticForTesting.products.Remove(DbStaticForTesting.products.Find(x => x.Id == id));

            return result;
        }
    }
}
