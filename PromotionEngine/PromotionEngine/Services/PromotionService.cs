using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Services
{
    public class PromotionService : IPromotionService
    {
        /// <summary>
        /// Fetches promotion based on PromotionId
        /// </summary>
        /// <param name="promotionId"></param>
        /// <returns></returns>
        public Promotion GetPromotion(string promotionId)
        {
            if (promotionId.Equals("Promotion1", StringComparison.OrdinalIgnoreCase))
            {
                //parameter promotionid is kept for future use
                Promotion promotion = new Promotion();
                promotion.Promotions = new List<PromotionItem>();
                promotion.Promotions.Add(new PromotionItem { Value = 130, Items = new List<Item> { new Item { SKUId = 'A', Quantity = 3 } } });
                promotion.Promotions.Add(new PromotionItem { Value = 45, Items = new List<Item> { new Item { SKUId = 'B', Quantity = 2 } } });
                promotion.Promotions.Add(new PromotionItem { Value = 30, Items = new List<Item> { new Item { SKUId = 'C', Quantity = 1 }, new Item { SKUId = 'D', Quantity = 1 } } });
                return promotion;
            }
            return null;
        }
    }
}
