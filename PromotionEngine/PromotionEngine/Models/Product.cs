using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    public class Product
    {
        public Product()
        {

        }
        public char SKUId { get; set; }
        public int Price { get; set; }
        public int AvailableQuantity { get; set; }
    }
}
