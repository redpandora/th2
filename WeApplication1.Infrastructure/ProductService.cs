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

        public Task<ProductData> Find(Guid productId)
        {
            throw new NotImplementedException();
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
    }
}
