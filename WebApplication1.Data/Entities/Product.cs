using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace WebApplication1.Data
{
    /// <summary>
    /// The product table on the database
    /// </summary>
    public class Product
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Configuration information for the Product entity
    /// </summary>
    public class ProductEntityConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ProductId);
        }
    }
}
