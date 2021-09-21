using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Services
{
    /// <summary>
    /// Interface for PromotionEngine
    /// </summary>
    interface IPromotionEngineService
    {
        /// <summary>
        /// Checkout
        /// </summary>
        /// <param name="promotionId"></param>
        /// <param name="cart"></param>
        /// <returns>Cart</returns>
        Cart CheckOut(string promotionId, Cart cart);
    }
}
