using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using WeApplication1.Infrastructure;

namespace WebApplication1.Data.Tests
{
    [TestClass]
    public class ProductServiceTests
    {
        private const string ProductOneID = "6A25F72C-AD13-43E1-9321-7A3A487BAFEB";
        private const string ProductOneName = "Product One";
        private const string ProductOneNewName = "Product One New Name";
        private const string ProductTwoID = "6FF6160E-CED3-4BB0-98C7-E4BF2D4BF3C4";

        [TestMethod]
        public async Task CanFindProductById()
        {
            // arrange
            Mock<IStorage> storageMock = new Mock<IStorage>();
            storageMock.Setup(m => m.Find(Guid.Parse(ProductOneID))).ReturnsAsync(new Product { ProductId = Guid.Parse(ProductOneID), Name = ProductOneName });

            var service = new ProductService(storageMock.Object);

            // act
            var product = await service.Find(Guid.Parse(ProductOneID));

            // assert
            Assert.IsNotNull(product);
        }
/*
        [TestMethod]
        public async Task CanFindProductByName()
        {
            // arrange
            IStorageContext storageContext = CreateMockContext("CanFindProductByName");
            var storage = new Storage(storageContext);

            // act
            var product = await storage.FindByName(ProductOneName);

            // assert
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public async Task CanUpdateProduct()
        {
            // arrange
            IStorageContext storageContext = CreateMockContext("CanUpdateProduct");
            var storage = new Storage(storageContext);
            var product = new Product { ProductId = Guid.Parse(ProductOneID), Name = ProductOneNewName };

            // act
            await storage.Update(product);

            // assert
            var name = storageContext.Products.Find(Guid.Parse(ProductOneID)).Name;

            Assert.AreEqual(ProductOneNewName, name);
        }        
*/
    }
}
