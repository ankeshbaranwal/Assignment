using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    /// <summary>
    /// PromotionItem
    /// </summary>
    public class PromotionItem
    {
        /// <summary>
        /// TypeOfPromotion
        /// </summary>
        public PromotionType TypeOfPromotion { get; set; }
        /// <summary>
        /// Items
        /// </summary>
        public List<Item> Items { get; set; }
        /// <summary>
        /// Value
        /// </summary>
        public int Value { get; set; }
    }
}
