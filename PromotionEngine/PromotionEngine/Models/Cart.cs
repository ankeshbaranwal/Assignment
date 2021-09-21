using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{

    public class Cart
    {
        public List<Item> Items { get; set; }
        public int TotalAmount { get; set; }
    }
}
