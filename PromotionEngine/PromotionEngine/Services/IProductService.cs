using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}
