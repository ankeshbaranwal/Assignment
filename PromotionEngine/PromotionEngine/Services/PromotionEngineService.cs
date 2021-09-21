using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PromotionEngine.Services
{
    public class PromotionEngineService : IPromotionEngineService
    {
        private readonly IPromotionService promotionService;
        private IProductService productService;
        public PromotionEngineService(IPromotionService promotionService, IProductService productService)
        {
            this.promotionService = promotionService;
            this.productService = productService;
        }
        public Cart CheckOut(string promotionId, Cart cart)
        {
            Promotion promotion = promotionService.GetPromotion(promotionId);
            List<Item> listOfItemsEligibleForPromotion = null;
            List<Item> cartOrderedItems = cart.Items;

            if (promotion == null)
            {
                throw new Exception("Invalid Promotion Id");
            }
            int TotalAmount = 0;
            foreach (var promotionItem in promotion.Promotions)
            {
                int promotionCnt = promotionItem.Items.Count;
                listOfItemsEligibleForPromotion = new List<Item>();
                int cnt = 0;
                foreach (var promoItem in promotionItem.Items)
                {
                    cnt++;
                    var itemEligibleForPromotion = cartOrderedItems.Where(p => p.SKUId == promoItem.SKUId && p.Quantity >= promoItem.Quantity).FirstOrDefault();

                    if (itemEligibleForPromotion != null)
                    {
                        cartOrderedItems.Remove(itemEligibleForPromotion);
                        listOfItemsEligibleForPromotion.Add(new Item { SKUId = itemEligibleForPromotion.SKUId, Quantity = itemEligibleForPromotion.Quantity });
                    }
                    if (cnt == promotionItem.Items.Count)
                    {
                        if (listOfItemsEligibleForPromotion.Count > 0 && listOfItemsEligibleForPromotion.Count != cnt)
                        {
                            cartOrderedItems.AddRange(listOfItemsEligibleForPromotion);
                            listOfItemsEligibleForPromotion = null;
                        }
                    }
                }
                if (listOfItemsEligibleForPromotion != null && listOfItemsEligibleForPromotion.Count > 0)
                {
                    bool isExists = listOfItemsEligibleForPromotion.Count == promotionItem.Items.Count;
                    if (isExists)
                    {
                        while (isExists)
                        {
                            TotalAmount += promotionItem.Value;
                            foreach (var promoItem in promotionItem.Items)
                            {
                                var xx = listOfItemsEligibleForPromotion.Where(p => p.SKUId == promoItem.SKUId).FirstOrDefault();
                                xx.Quantity -= promoItem.Quantity;
                                isExists = xx.Quantity >= promoItem.Quantity;
                            }
                        }
                        cartOrderedItems.AddRange(listOfItemsEligibleForPromotion);
                    }
                }
            }
            //Calculate Amount for Non Promotional Items
            var products = this.productService.GetProducts();
            foreach (var item in cartOrderedItems)
            {
                if (item.Quantity > 0)
                {
                    var prod = products.FirstOrDefault(p => p.SKUId == item.SKUId);
                    if (prod != null)
                    {
                        TotalAmount += (prod.Price * item.Quantity);
                    }
                }
            }
            cart.TotalAmount = TotalAmount;
            return cart;
        }
    }
}
