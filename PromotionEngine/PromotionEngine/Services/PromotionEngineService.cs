using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PromotionEngine.Extension;
using PromotionEngine.Exceptions;

namespace PromotionEngine.Services
{
    /// <summary>
    /// PromotionEngineService: Class responsible for applying promotion to Cart
    /// </summary>
    public class PromotionEngineService : IPromotionEngineService
    {
        private readonly IPromotionService promotionService;
        private IProductService productService;
        private List<Item> cartOrderedItems;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="promotionService"></param>
        /// <param name="productService"></param>
        public PromotionEngineService(IPromotionService promotionService, IProductService productService)
        {
            this.promotionService = promotionService;
            this.productService = productService;
        }
        /// <summary>
        ///Checkout: Applies promotion and calculates the total amount after promotion
        /// </summary>
        /// <param name="promotionId"></param>
        /// <param name="cart"></param>
        /// <returns></returns>
        public Cart CheckOut(string promotionId, Cart cart)
        {
            if (IsValidCart(cart))
            {
                Promotion promotion = promotionService.GetPromotion(promotionId);
                if (promotion == null)
                    throw new InvalidPromotionCodeException($"No Promotion found with promotion id:{promotionId}");
                if (!promotion.IsActive)
                    throw new InActivePromotionCode($"Promotion id:{promotionId} is inActive");

                cartOrderedItems = cart.Items.GetClone();

                int TotalAmount = 0;
                foreach (var promotionItem in promotion.Promotions)
                {
                    if (promotionItem.TypeOfPromotion == PromotionType.Flat)
                    {
                        var orderItemsElegibleForPromotions = BuildPromotionEligibleItemsListForPromotionItem(promotionItem);
                        TotalAmount += CalculateAmountForPromotion(promotionItem, orderItemsElegibleForPromotions);
                    }


                }
                //Calculate Amount for Non Promotional Items
                TotalAmount += CalculateAmountForNonPromotionalItem();
                cart.TotalAmount = TotalAmount;

            }
            return cart;
        }

        /// <summary>
        /// Validates whether items in the cart is valid or not
        /// </summary>
        /// <param name="cart"></param>
        /// <returns></returns>
        private bool IsValidCart(Cart mycart)
        {
            if (mycart == null || mycart.Items == null || mycart.Items.Count == 0)
            {
                throw new PromotionEngineArgumentException("Cart does not contain any item");
            }
            var products = productService.GetProducts();
            foreach (var item in mycart.Items)
            {
                var prod = products.FirstOrDefault(p => p.SKUId == item.SKUId && p.AvailableQuantity >= item.Quantity);
                if (prod == null)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// BuildPromotionEligibleItemsListForPromotionItem: Creates a list of item which are eligible for promotion
        /// </summary>
        /// <param name="promotionItem"></param>
        /// <returns></returns>
        private List<Item> BuildPromotionEligibleItemsListForPromotionItem(PromotionItem promotionItem)
        {
            int cnt = 0;
            List<Item> orderItemsElegibleForPromotions = new List<Item>();
            foreach (var promoItem in promotionItem.Items)
            {
                cnt++;
                var itemEligibleForPromotion = cartOrderedItems.Where(p => p.SKUId == promoItem.SKUId && p.Quantity >= promoItem.Quantity).FirstOrDefault();

                if (itemEligibleForPromotion != null)
                {
                    cartOrderedItems.Remove(itemEligibleForPromotion);
                    orderItemsElegibleForPromotions.Add(new Item(itemEligibleForPromotion));
                }
                if (cnt == promotionItem.Items.Count)
                {
                    if (orderItemsElegibleForPromotions.Count > 0 && orderItemsElegibleForPromotions.Count != cnt)
                    {
                        cartOrderedItems.AddRange(orderItemsElegibleForPromotions);
                        orderItemsElegibleForPromotions = null;
                    }
                }
            }
            return orderItemsElegibleForPromotions;
        }

        /// <summary>
        /// CalculateAmountForPromotion: Calcualtes the total amount of items which are eligible for promotions.
        /// </summary>
        /// <param name="promotionItem"></param>
        /// <param name="listOfItemsEligibleForPromotion"></param>
        /// <returns></returns>
        private int CalculateAmountForPromotion(PromotionItem promotionItem, List<Item> orderItemsElegibleForPromotions)
        {
            int totalAmount = 0;
            if (orderItemsElegibleForPromotions != null && orderItemsElegibleForPromotions.Count > 0)
            {
                bool isExists = orderItemsElegibleForPromotions.Count == promotionItem.Items.Count;
                if (isExists)
                {
                    while (isExists)
                    {
                        totalAmount += promotionItem.Value;
                        foreach (var promoItem in promotionItem.Items)
                        {
                            var item = orderItemsElegibleForPromotions.Where(p => p.SKUId == promoItem.SKUId).FirstOrDefault();
                            item.Quantity -= promoItem.Quantity;
                            isExists = item.Quantity >= promoItem.Quantity;
                        }
                    }
                    cartOrderedItems.AddRange(orderItemsElegibleForPromotions);
                }
            }
            return totalAmount;
        }

        /// <summary>
        /// CalculateAmountForNonPromotionalItem: Calculate amount for item which are not eligible for promotion
        /// </summary>
        /// <returns></returns>
        private int CalculateAmountForNonPromotionalItem()
        {
            int totalAmount = 0;
            var products = this.productService.GetProducts();
            foreach (var item in cartOrderedItems)
            {
                if (item.Quantity > 0)
                {
                    var prod = products.FirstOrDefault(p => p.SKUId == item.SKUId);
                    if (prod != null)
                    {
                        totalAmount += (prod.Price * item.Quantity);
                    }
                }
            }
            return totalAmount;
        }
    }
}
