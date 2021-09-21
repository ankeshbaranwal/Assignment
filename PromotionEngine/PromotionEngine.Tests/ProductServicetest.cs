using NUnit.Framework;
using PromotionEngine.Models;
using PromotionEngine.Services;

namespace PromotionEngine.Tests
{
    public class ProductServiceTest
    {

        private ProductService productService;
        private PromotionService promotionService;
        private PromotionEngineService engineService;

        [SetUp]
        public void Setup()
        {
            productService = new ProductService();

        }

        [Test]
        public void GetProduct_Returns_ListOfProducts()
        {
            var products = productService.GetProducts();
            Assert.IsNotNull(products);

        }

    }
}