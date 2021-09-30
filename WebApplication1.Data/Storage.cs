using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class Storage : IStorage
    {
        private IStorageContext storageContext;

        public Storage(IStorageContext storageContext)
        {
            this.storageContext = storageContext;
        }

        public async Task<Guid> Add(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Find(Guid productId)
        {
            var query = (from product in storageContext.Products
                         where productId == product.ProductId
                         select product);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Product> FindByName(Guid productId)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
