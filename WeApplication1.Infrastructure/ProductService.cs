using Microsoft.Extensions.Logging;
using System;
using System.Threading;
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

        public async Task<ProductData> Find(Guid productId, CancellationToken cancellationToken = default)
        {
            logger.LogInformation
            var product = await storage.Find(productId, cancellationToken);

            return FromProduct(product);
        }

        public async Task<ProductData> FindByName(string productName, CancellationToken cancellationToken = default)
        {
            var product = await storage.FindByName(productName, cancellationToken);

            return FromProduct(product);
        }

        public async Task StoreProduct(ProductData product, CancellationToken cancellationToken = default)
        {
            Product productToAdd = ToProduct(product);
            await storage.Add(productToAdd);
            product.ProductId = productToAdd.ProductId;
        }

        public async Task UpdateProduct(ProductData product)
        {
            Product productToAdd = ToProduct(product);
            await storage.Update(productToAdd);
        }

        private Product ToProduct(ProductData product)
        {
            return new Product
            {
                Name = product.Name,
                ProductId = product.ProductId
            };
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
