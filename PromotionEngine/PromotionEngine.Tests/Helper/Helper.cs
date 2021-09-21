using PromotionEngine.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Tests.Helper
{
    static class Helper
    {
        public  static CartService InitializeCartServiceWithCart(string scenario, ProductService productService)
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
