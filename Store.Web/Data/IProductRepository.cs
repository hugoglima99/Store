

namespace Store.Web.Data
{
    using Store.Web.Data.Entities;
    using System.Linq;

    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable GetAllWithUsers();
    }
}
