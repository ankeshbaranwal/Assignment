using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    /// <summary>
    /// Item
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Item() { }
        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="item"></param>
        public Item(Item item)
        {
            this.SKUId = item.SKUId;
            this.Quantity = item.Quantity;
        }
        public char SKUId { get; set; }
        public int Quantity { get; set; }
    }
}
