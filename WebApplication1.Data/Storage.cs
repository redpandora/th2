using System;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class Storage : IStorage
    {
        Task<Guid> IStorage.Add(Product product)
        {
            throw new NotImplementedException();
        }

        Task<Product> IStorage.Find(Guid productId)
        {
            throw new NotImplementedException();
        }

        Task<Product> IStorage.FindByName(Guid productId)
        {
            throw new NotImplementedException();
        }

        Task IStorage.Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
