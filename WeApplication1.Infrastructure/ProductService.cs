using System;
using System.Threading.Tasks;
using WeApplication1.Infrastructure.Models;
using WebApplication1.Data;

namespace WeApplication1.Infrastructure
{
    public class ProductService : IProductService
    {
        private readonly IStorage storage;

        public ProductService(IStorage storage)
        {
            this.storage = storage;
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
