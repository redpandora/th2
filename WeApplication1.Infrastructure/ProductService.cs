using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WeApplication1.Infrastructure.Models;
using WebApplication1.Data;

namespace WeApplication1.Infrastructure
{
    public class ProductService : IProductService
    {
        private readonly IStorage storage;
        private readonly ILogger<ProductService> logger;

        public ProductService(IStorage storage, ILogger<ProductService> logger)
        {
            this.storage = storage ?? throw new ArgumentNullException(nameof(storage));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ProductData> Find(Guid productId)
        {
            var product = await storage.Find(productId);

            return FromProduct(product);
        }

        public Task<ProductData> FindByName(string productName)
        {
            throw new NotImplementedException();
        }

        public Task<Guid> StoreProduct(ProductData product)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProduct(ProductData product)
        {
            throw new NotImplementedException();
        }

        private ProductData FromProduct(Product product)
        {
            return new ProductData
            {
                Name = product.Name,
                ProductId = product.ProductId
            };
        }
    }
}
