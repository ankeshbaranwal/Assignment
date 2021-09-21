using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    /// <summary>
    /// Cart
    /// </summary>
    public class Cart
    {
        /// <summary>
        /// Items
        /// </summary>
        public List<Item> Items { get; set; }
        /// <summary>
        /// TotalAmount
        /// </summary>
        public int TotalAmount { get; set; }
    }
}
