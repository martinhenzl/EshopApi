namespace EshopApi.Tests
{
    using Xunit;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using EshopApi.Controllers;
    using EshopApi.Data;

    public class ProductsControllerTests
    {
        private ProductsController _controller;
        private ProductDbContext _context;

        public ProductsControllerTests()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseInMemoryDatabase(databaseName: "EshopDB")
                .Options;
            _context = new ProductDbContext(options);
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
            SeedTestData();
            _controller = new ProductsController(_context);
        }

        private void SeedTestData()
        {
            _context.Products.AddRange(new List<Product>
        {
            new Product { Id = 1, Name = "Test Laptop", ImgUri = "laptop.jpg", Price = 899.99M, Description = "Test high-performance laptop" },
            new Product { Id = 2, Name = "Test Phone", ImgUri = "phone.jpg", Price = 499.99M, Description = "Test smartphone" }
        });
            _context.SaveChanges();
        }

        [Fact]
        public void GetAllProducts_ReturnsAllProducts()
        {
            var result = _controller.GetAllProducts() as OkObjectResult;
            Assert.NotNull(result);
            var products = Assert.IsType<List<Product>>(result.Value);
            Assert.Equal(2, products.Count);
        }

        [Fact]
        public void GetProducts_ReturnsPaginatedProducts()
        {
            var result = _controller.GetProducts(1, 1) as OkObjectResult;
            Assert.NotNull(result);
            var products = Assert.IsType<List<Product>>(result.Value);
            Assert.Single(products);
        }

        [Fact]
        public void GetProduct_ReturnsProduct_WhenExists()
        {
            var result = _controller.GetProduct(1) as OkObjectResult;
            Assert.NotNull(result);
            var product = Assert.IsType<Product>(result.Value);
            Assert.Equal("Test Laptop", product.Name);
        }

        [Fact]
        public void GetProduct_ReturnsNotFound_WhenDoesNotExist()
        {
            var result = _controller.GetProduct(99);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void UpdateProductDescription_UpdatesProduct_WhenExists()
        {
            //var updateResult = _controller.UpdateProductDescription(1, "Updated Description");
            var updateResult = _controller.UpdateProductDescription(1, new UpdateDescriptionDto { Description = "Updated Description" });
            var updatedProduct = _context.Products.Find(1);

            Assert.IsType<NoContentResult>(updateResult);
            Assert.NotNull(updatedProduct);
            Assert.Equal("Updated Description", updatedProduct.Description);
        }

        [Fact]
        public void UpdateProductDescription_ReturnsNotFound_WhenDoesNotExist()
        {
            //var result = _controller.UpdateProductDescription(99, "New Description");
            var result = _controller.UpdateProductDescription(99, new UpdateDescriptionDto { Description = "Updated Description" });
            Assert.IsType<NotFoundResult>(result);
        }
    }

}
