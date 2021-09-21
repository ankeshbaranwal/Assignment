using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    class Cart
    {
        public List<Item> Items { get; set; }
        public int TotalAmount { get; set; }
    }
}
