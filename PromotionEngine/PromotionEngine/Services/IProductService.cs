using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Services
{
    /// <summary>
    /// IProductService
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// GetProducts: returns Ienumerable list of products
        /// </summary>
        /// <returns></returns>
        IEnumerable<Product> GetProducts();
    }
}
