using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    public class PromotionItem
    {
        public PromotionType TypeOfPromotion { get; set; }
        public List<Item> Items { get; set; }
        public int Value { get; set; }
    }
}
