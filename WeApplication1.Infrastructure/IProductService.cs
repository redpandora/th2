using System;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WeApplication1.Infrastructure
{
    public interface IProductService
    {
        Task<Product> Find(Guid productId);
        Task<Product> FindByName(string productName);
        Task<Guid> StoreProduct(Product product);
        Task UpdateProduct(Product product);
    }
}
