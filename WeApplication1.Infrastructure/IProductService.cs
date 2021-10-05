using System;
using System.Threading;
using System.Threading.Tasks;
using WeApplication1.Infrastructure.Models;
using WebApplication1.Data;

namespace WeApplication1.Infrastructure
{
    public interface IProductService
    {
        Task<ProductData> Find(Guid productId, CancellationToken cancellationToken = default);
        Task<ProductData> FindByName(string productName, CancellationToken cancellationToken = default);
        Task StoreProduct(ProductData product, CancellationToken cancellationToken = default);
        Task UpdateProduct(ProductData product);
    }
}
