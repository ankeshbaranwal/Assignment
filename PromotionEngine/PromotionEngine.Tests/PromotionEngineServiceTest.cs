using NUnit.Framework;
using PromotionEngine.Exceptions;
using PromotionEngine.Models;
using PromotionEngine.Services;
using System;

namespace PromotionEngine.Tests
{
    public class PromotionEngineServicetest
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

        [Test]
        public void PromotionEngineService_Checkout_Invalid_PromotionCode()
        {
            CartService cartService = Helper.Helper.InitializeCartServiceWithCart("Scenario A", productService);
            InvalidPromotionCodeException ex = Assert.Throws<InvalidPromotionCodeException>(() => engineService.CheckOut("Promotion2", cartService.GetCart()));
            Assert.IsNotNull(ex);
            Assert.AreEqual("No Promotion found with promotion id:Promotion2", ex.Message);

        }

        [Test]
        public void PromotionEngineService_Checkout_Inactive_PromotionCode()
        {
            CartService cartService = Helper.Helper.InitializeCartServiceWithCart("Scenario A", productService);
            InActivePromotionCode ex = Assert.Throws<InActivePromotionCode>(() => engineService.CheckOut("Promotion5", cartService.GetCart()));
            Assert.IsNotNull(ex);
            Assert.AreEqual("Promotion id:Promotion5 is inActive", ex.Message);

        }

        [Test]
        public void PromotionEngineService_Checkout_Null_Cart_Throws_ArgumentException()
        {
            CartService cartService = Helper.Helper.InitializeCartServiceWithCart("Scenario A", productService);
            PromotionEngineArgumentException ex = Assert.Throws<PromotionEngineArgumentException>(() => engineService.CheckOut("Promotion1", null));
            Assert.AreEqual("Cart does not contain any item", ex.Message);

        }
    }
}