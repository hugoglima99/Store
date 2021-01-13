using Store.Web.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Web.Data
{
    public interface IRepository
    {
        void AddProduct(Product product);
        Product GetProduct(int id);
        IEnumerable<Product> GetProducts();
        bool ProductExists(int id);
        void RemoveProduct(Product product);
        Task<bool> SaveAllSync();
        void UpdateProduct(Product product);
        object GetProducts(int value);
        void RemoveProduct(object product);
    }
}