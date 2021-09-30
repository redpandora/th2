using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    interface IStorage
    {
        Task<Product> Find(Guid productId);
        Task<Product> FindByName(Guid productId);
        Task<Guid> Add(Product product);
        Task Update(Product product);
    }
}
