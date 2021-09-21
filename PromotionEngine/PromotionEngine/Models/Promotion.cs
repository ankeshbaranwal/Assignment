using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Models
{
    /// <summary>
    /// Promotion
    /// </summary>
    public class Promotion
    {
        /// <summary>
        /// PromotionId
        /// </summary>
        public string PromotionId { get; set; }
        /// <summary>
        /// PromotionId
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// PromotionId
        /// </summary>
        public List<PromotionItem> Promotions { get; set; }
    }
}
