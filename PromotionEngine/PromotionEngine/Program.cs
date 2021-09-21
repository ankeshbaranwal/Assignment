using PromotionEngine.Services;
using System;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductService productService = new ProductService();
            CartService cartService = InitializeCartServiceWithCart("Scenario B", productService);
            PromotionService promotionService = new PromotionService();
            PromotionEngineService engineService = new PromotionEngineService(promotionService, productService);
            engineService.CheckOut("Promotion1", cartService.GetCart());
        }

        private static CartService InitializeCartServiceWithCart(string scenario, ProductService productService)
        {
            CartService cartService = new CartService(productService);
            if (scenario.Equals("Scenario A", StringComparison.OrdinalIgnoreCase))
            {
                cartService.AddToCart('A', 1);
                cartService.AddToCart('B', 1);
                cartService.AddToCart('C', 1);
            }
            else if (scenario.Equals("Scenario B", StringComparison.OrdinalIgnoreCase))
            {
                cartService.AddToCart('A', 5);
                cartService.AddToCart('B', 5);
                cartService.AddToCart('C', 1);
            }
            else if (scenario.Equals("Scenario C", StringComparison.OrdinalIgnoreCase))
            {
                cartService.AddToCart('A', 3);
                cartService.AddToCart('B', 5);
                cartService.AddToCart('C', 1);
                cartService.AddToCart('D', 1);
            }
            return cartService;
        }
    }
}
