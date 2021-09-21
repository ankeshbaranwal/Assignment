using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product
    {
        public Product()
        {

        }
        /// <summary>
        /// SKUId
        /// </summary>
        public char SKUId { get; set; }
        /// <summary>
        /// Price
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// AvailableQuantity
        /// </summary>
        public int AvailableQuantity { get; set; }
    }
}
