using System;
using System.Threading.Tasks;
using WeApplication1.Infrastructure.Models;
using WebApplication1.Data;

namespace WeApplication1.Infrastructure
{
    public interface IProductService
    {
        Task<ProductData> Find(Guid productId);
        Task<ProductData> FindByName(string productName);
        Task<Guid> StoreProduct(ProductData product);
        Task UpdateProduct(ProductData product);
    }
}
