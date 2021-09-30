using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    /// <summary>
    /// Storage contract for the product storage
    /// </summary>
    public interface IStorage
    {
        /// <summary>
        /// Find a product by ID
        /// </summary>
        /// <param name="productId">The ID to search for</param>
        /// <returns>The product with that ID</returns>
        Task<Product> Find(Guid productId);
        Task<Product> FindByName(Guid productId);
        Task<Guid> Add(Product product);
        Task Update(Product product);
    }
}
