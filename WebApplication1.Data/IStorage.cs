using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
        /// <returns>The product with that ID</returns>
        Task<Product> Find(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Find a product by name
        /// </summary>
        /// <param name="name">name to search for</param>
        /// <param name="cancellationToken">Async cancelation token</param>
        /// <returns>The product with that name</returns>
        Task<Product> FindByName(string name, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds a new product to storage
        /// </summary>
        /// <param name="product"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Add(Product product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates the details of a product on storage
        /// </summary>
        /// <param name="product"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task Update(Product product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Returns all products on the database
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>The queriable list of products</returns>
        IQueryable<Product> GetAll(CancellationToken cancellationToken = default);
    }
}
