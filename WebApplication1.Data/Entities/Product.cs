using System;

namespace WebApplication1.Data
{
    /// <summary>
    /// The product data in the database
    /// </summary>
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
    }
}
