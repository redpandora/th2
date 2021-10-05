using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class Storage : IStorage
    {
        private readonly IStorageContext storageContext;

        public Storage(IStorageContext storageContext)
        {
            this.storageContext = storageContext;
        }

        public async Task Add(Product product, CancellationToken cancellationToken = default)
        {
            this.storageContext.Products.Add(product);
            await storageContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Product> Find(Guid id, CancellationToken cancellationToken = default)
        {
            return await storageContext.Products.FindAsync(id, cancellationToken);
        }

        public async Task<Product> FindByName(string name, CancellationToken cancellationToken = default)
        {
            var query = (from product in storageContext.Products
                         where name == product.Name
                         select product);
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public IQueryable<Product> GetAll(CancellationToken cancellationToken = default)
        {
            return storageContext.Products;
        }

        public async Task Update(Product product, CancellationToken cancellationToken = default)
        {
            var originalProduct = await Find(product.ProductId);
            if (originalProduct == null) throw new InvalidOperationException($"Product with {product.ProductId} not found");

            // update values
            originalProduct.Name = product.Name;

            await storageContext.SaveChangesAsync(cancellationToken);
        }
    }
}
