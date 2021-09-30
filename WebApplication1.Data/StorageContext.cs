using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    /// <summary>
    /// The database context implementation
    /// </summary>
    public class StorageContext : DbContext, IStorageContext
    {
        public StorageContext(DbContextOptions<StorageContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
