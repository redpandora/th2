using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WebApplication1.Data.Tests
{
    [TestClass]
    public class StorageTests
    {
        private const string ProductOneID = "6A25F72C-AD13-43E1-9321-7A3A487BAFEB";
        private const string ProductTwoID = "6FF6160E-CED3-4BB0-98C7-E4BF2D4BF3C4";

        [TestMethod]
        public void CanFindProductById()
        {
            // arrange
            IStorageContext storageContext = CreateMockContext();
            var storage = new Storage(storageContext);

            // act
            var product = storage.Find(Guid.Parse(ProductOneID));

            // assert
            Assert.IsNotNull(product);
        }


        /// <summary>
        /// Create a mock context
        /// </summary>
        /// <returns></returns>
        private IStorageContext CreateMockContext()
        {
            var options = new DbContextOptionsBuilder<StorageContext>()
            .UseInMemoryDatabase(databaseName: "TestDataBase")
            .Options;

            StorageContext storageContext = new StorageContext(options);
            storageContext.Products.Add(new Product { ProductId = Guid.Parse(ProductOneID),Name = "Product One" });

            return storageContext;
        }
    }
}
