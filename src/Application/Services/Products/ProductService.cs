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
            _product.SetStatus(ProductStatus.Ativo);
            _product.SetQuantity(0);

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

        public bool StockEntry(Product product, int quantity)
        {
            if (product == null || quantity <= 0) return false;

            try
            {
                int quantityAftr = DbStaticForTesting.products.Find(x => x.Id == product.Id).Quantity + quantity;

                DbStaticForTesting.products.Find(x => x.Id == product.Id).SetQuantity(quantityAftr);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool StockIssue(Product product, int quantity)
        {
            if (product == null || quantity >= 0) return false;

            try
            {
                int quantityAftr = DbStaticForTesting.products.Find(x => x.Id == product.Id).Quantity + quantity;

                if (quantityAftr > 0)
                {
                    DbStaticForTesting.products.Find(x => x.Id == product.Id).SetQuantity(quantityAftr);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _product = DbStaticForTesting.products.Find(x => x.Id == id);
                if (_product.Quantity == 0)
                {
                    DbStaticForTesting.products.Remove(DbStaticForTesting.products.Find(x => x.Id == id));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ForcedDelete(int id)
        {
            bool result = true;

            DbStaticForTesting.products.Remove(DbStaticForTesting.products.Find(x => x.Id == id));

            return result;
        }
    }
}
