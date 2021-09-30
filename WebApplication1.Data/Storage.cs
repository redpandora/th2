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

        public async Task<Product> Find(Guid id)
        {
            return await storageContext.Products.FindAsync(id);
        }

        public async Task<Product> FindByName(string name)
        {
            var query = (from product in storageContext.Products
                         where name == product.Name
                         select product);
            return await query.FirstOrDefaultAsync();
        }

        public async Task Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
