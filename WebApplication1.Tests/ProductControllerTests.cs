using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using WeApplication1.Infrastructure;
using WeApplication1.Infrastructure.Models;
using WebApplication1.Controllers;

namespace WebApplication1.Tests
{
    [TestClass]
    public class ProductControllerTests
    {
        private const string ProductOneID = "6A25F72C-AD13-43E1-9321-7A3A487BAFEB";
        private const string ProductOneName = "Product One";

        [TestMethod]
        public async Task CanFindById()
        {
            // arrange

            Mock<IProductService> productService = new Mock<IProductService>();
            productService.Setup(m => m.Find(Guid.Parse(ProductOneID))).ReturnsAsync(new ProductData { ProductId = Guid.Parse(ProductOneID), Name = ProductOneName });

            ProductController controller = new ProductController(productService.Object);

            // act
            var result = await controller.GetProduct(Guid.Parse(ProductOneID));

            // assert
            OkObjectResult objectResult = result as OkObjectResult; // Implict Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.IsNotNull(objectResult);

            ProductData data = objectResult.Value as ProductData;
            Assert.IsNotNull(data);

            Assert.AreEqual(ProductOneName, data.Name);
        }
    }
}
