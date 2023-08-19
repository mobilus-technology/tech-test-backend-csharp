using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using WebApiProduct.Interface;
using WebApiProduct.Models;
using WebApiProduct.Service;
using ProductService = WebApiProduct.Service.ProductService;

namespace Tests
{
    [TestClass]
    public class ProductServiceTests
    {
        [TestMethod]
        public void CreateProduct_ShouldAddProductToRepository()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            var productService = new ProductService(mockRepository.Object);
            var newProduct = new Product { Nome = "Test Product", Preco = 10.0m, Estoque = 5 };

            // Act
            productService.CreateProduct(newProduct);

            // Assert
            mockRepository.Verify(repo => repo.Create(It.IsAny<Product>()), Times.Once);
        }

        [TestMethod]
        public void GetProductById_ShouldReturnProductIfExists()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            var productService = new ProductService(mockRepository.Object);
            var existingProduct = new Product { Id = 1, Nome = "Existing Product", Preco = 20.0m, Estoque = 8 };
            mockRepository.Setup(repo => repo.GetById(1)).Returns(existingProduct);

            // Act
            var result = productService.GetProductById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(existingProduct.Id, result.Id);
        }

        [TestMethod]
        public void UpdateProduct_ShouldUpdateProductInRepository()
        {
            // Arrange
            var mockRepository = new Mock<IProductRepository>();
            var productService = new ProductService(mockRepository.Object);
            var existingProduct = new Product { Id = 1, Nome = "Existing Product", Preco = 20.0m, Estoque = 8 };
            mockRepository.Setup(repo => repo.GetById(1)).Returns(existingProduct);

            // Act
            productService.UpdateProduct(existingProduct);

            // Assert
            mockRepository.Verify(repo => repo.Update(It.IsAny<Product>()), Times.Once);
        }
    }
}
