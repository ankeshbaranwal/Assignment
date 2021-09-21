using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Services
{
    /// <summary>
    /// ICartService
    /// </summary>
    public interface ICartService
    {
        /// <summary>
        /// GetCart- Get Cart items
        /// </summary>
        /// <param name="scenario"></param>
        /// <returns></returns>
        Cart GetCart();

        /// <summary>
        /// AddToCart- Add product to Cart
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        bool AddToCart(char prodId, int quantity);

       
    }
}
