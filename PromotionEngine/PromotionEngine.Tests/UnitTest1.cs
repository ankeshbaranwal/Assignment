using NUnit.Framework;
using PromotionEngine.Models;
using PromotionEngine.Services;

namespace PromotionEngine.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            ProductService productService = new ProductService();
           
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}