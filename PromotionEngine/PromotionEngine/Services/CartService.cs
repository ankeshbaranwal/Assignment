using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PromotionEngine.Services
{
    class CartService : ICartService
    {
        private readonly IProductService productService;
        private readonly Cart cart;
        public CartService(IProductService productService)
        {
            this.productService = productService;
            this.cart = new Cart { Items = new List<Item>() };
        }

        /// <summary>
        /// Add a product to Cart items
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool AddToCart(char prodId, int quantity)
        {
            var products = productService.GetProducts().ToList();
            var prod = products.Where(p => p.SKUId == prodId && p.AvailableQuantity >= quantity).FirstOrDefault();
            if (prod != null)
            {
                var item = this.cart.Items.Where(p => p.SKUId == prodId).FirstOrDefault();
                if (item != null)
                {
                    item.Quantity += quantity;
                }
                else
                {
                    this.cart.Items.Add(new Item { SKUId = prodId, Quantity = quantity });
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get Cart Items based on scenario
        /// </summary>
        /// <param name="scenario"></param>
        /// <returns></returns>
        public Cart GetCart()
        {
            return cart;
        }

       
    }
}
