using NUnit.Framework;
using PromotionEngine.Models;
using PromotionEngine.Services;

namespace PromotionEngine.Tests
{
    public class Tests
    {

        private ProductService productService;
        private PromotionService promotionService;
        private PromotionEngineService engineService;

        [SetUp]
        public void Setup()
        {
            productService = new ProductService();

            promotionService = new PromotionService();


            engineService = new PromotionEngineService(promotionService, productService);
        }

        [Test]
        public void PromotionEngineService_Checkout_Scenario_A()
        {
            CartService cartService = Helper.Helper.InitializeCartServiceWithCart("Scenario A", productService);
            Cart cart = engineService.CheckOut("Promotion1", cartService.GetCart());
            Assert.IsNotNull(cart);
            Assert.IsNotNull(cart.Items);
            Assert.AreEqual(100, cart.TotalAmount);

        }

        [Test]
        public void PromotionEngineService_Checkout_Scenario_B()
        {
            CartService cartService = Helper.Helper.InitializeCartServiceWithCart("Scenario B", productService);
            Cart cart = engineService.CheckOut("Promotion1", cartService.GetCart());
            Assert.IsNotNull(cart);
            Assert.IsNotNull(cart.Items);
            Assert.AreEqual(370, cart.TotalAmount);

        }

        [Test]
        public void PromotionEngineService_Checkout_Scenario_C()
        {
            CartService cartService = Helper.Helper.InitializeCartServiceWithCart("Scenario C", productService);
            Cart cart = engineService.CheckOut("Promotion1", cartService.GetCart());
            Assert.IsNotNull(cart);
            Assert.IsNotNull(cart.Items);
            Assert.AreEqual(280, cart.TotalAmount);

        }
    }
}