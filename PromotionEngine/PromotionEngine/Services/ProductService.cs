using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Services
{
    public class ProductService : IProductService
    {
        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product { SKUId = 'A', Price = 50, AvailableQuantity = 100 });
            products.Add(new Product { SKUId = 'B', Price = 30, AvailableQuantity = 100 });
            products.Add(new Product { SKUId = 'C', Price = 20, AvailableQuantity = 100 });
            products.Add(new Product { SKUId = 'D', Price = 15, AvailableQuantity = 100 });
            return products;
        }
    }
}
