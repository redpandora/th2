using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using WeApplication1.Infrastructure;
using WeApplication1.Infrastructure.Models;

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

        [TestMethod]
        public async Task CanFindProductByName()
        {
            // arrange
            Mock<IStorage> storageMock = new Mock<IStorage>();
            storageMock.Setup(m => m.FindByName(ProductOneName)).ReturnsAsync(new Product { ProductId = Guid.Parse(ProductOneID), Name = ProductOneName });

            var service = new ProductService(storageMock.Object);

            // act
            var product = await service.FindByName(ProductOneName);

            // assert
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public async Task CanUpdateProduct()
        {
            // arrange
            Mock<IStorage> storageMock = new Mock<IStorage>();
            Product updatedProduct = null;

            storageMock.Setup(m => m.Update(It.IsAny<Product>())).Callback((Product product) => updatedProduct = product);
            var service = new ProductService(storageMock.Object);

            // act
            await service.UpdateProduct(new ProductData { ProductId = Guid.Parse(ProductOneID), Name = ProductOneNewName });

            // assert
            Assert.AreEqual(updatedProduct.Name, ProductOneNewName);
        }

    }
}
