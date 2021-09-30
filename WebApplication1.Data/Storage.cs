using System;
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
            throw new NotImplementedException();
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
