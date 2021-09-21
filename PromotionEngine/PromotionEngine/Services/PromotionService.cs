using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace PromotionEngine.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly List<Promotion> promotions;
        public PromotionService()
        {
            promotions = new List<Promotion>();
            Promotion promotion = new Promotion();
            promotion.PromotionId = "Promotion1";
            promotion.IsActive = true;
            promotion.Promotions = new List<PromotionItem>();
            promotion.Promotions.Add(new PromotionItem { TypeOfPromotion = PromotionType.Flat, Value = 130, Items = new List<Item> { new Item { SKUId = 'A', Quantity = 3 } } });
            promotion.Promotions.Add(new PromotionItem { TypeOfPromotion = PromotionType.Flat, Value = 45, Items = new List<Item> { new Item { SKUId = 'B', Quantity = 2 } } });
            promotion.Promotions.Add(new PromotionItem { TypeOfPromotion = PromotionType.Flat, Value = 30, Items = new List<Item> { new Item { SKUId = 'C', Quantity = 1 }, new Item { SKUId = 'D', Quantity = 1 } } });
            promotions.Add(promotion);
            //InActive Promotion
            promotion = new Promotion();
            promotion.PromotionId = "Promotion5";
            promotion.IsActive = false;
            promotion.Promotions = new List<PromotionItem>();
            promotion.Promotions.Add(new PromotionItem { TypeOfPromotion = PromotionType.Flat, Value = 130, Items = new List<Item> { new Item { SKUId = 'A', Quantity = 3 } } });
            promotion.Promotions.Add(new PromotionItem { TypeOfPromotion = PromotionType.Flat, Value = 45, Items = new List<Item> { new Item { SKUId = 'B', Quantity = 2 } } });
            promotion.Promotions.Add(new PromotionItem { TypeOfPromotion = PromotionType.Flat, Value = 30, Items = new List<Item> { new Item { SKUId = 'C', Quantity = 1 }, new Item { SKUId = 'D', Quantity = 1 } } });
            promotions.Add(promotion);

        }
        /// <summary>
        /// Fetches promotion based on PromotionId
        /// </summary>
        /// <param name="promotionId"></param>
        /// <returns></returns>
        public Promotion GetPromotion(string promotionId)
        {
            return this.promotions.FirstOrDefault(p => p.PromotionId.Equals(promotionId, StringComparison.OrdinalIgnoreCase));
        }
    }
}
