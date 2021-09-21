using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using PromotionEngine.Extension;

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
                cartOrderedItems = cart.Items.GetClone();

                if (promotion == null)
                {
                    throw new Exception("Invalid Promotion Id");
                }
                int TotalAmount = 0;
                foreach (var promotionItem in promotion.Promotions)
                {
                    var listOfItemsEligibleForPromotion = BuildPromotionEligibleItemsListForPromotionItem(promotionItem);
                    TotalAmount += CalculateAmountForPromotion(promotionItem, listOfItemsEligibleForPromotion);


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
                throw new ArgumentException("Cart does not contain any item");
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
            List<Item> listOfItemsEligibleForPromotion = new List<Item>();
            foreach (var promoItem in promotionItem.Items)
            {
                cnt++;
                var itemEligibleForPromotion = cartOrderedItems.Where(p => p.SKUId == promoItem.SKUId && p.Quantity >= promoItem.Quantity).FirstOrDefault();

                if (itemEligibleForPromotion != null)
                {
                    cartOrderedItems.Remove(itemEligibleForPromotion);
                    listOfItemsEligibleForPromotion.Add(new Item(itemEligibleForPromotion));
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
            return listOfItemsEligibleForPromotion;
        }

        /// <summary>
        /// CalculateAmountForPromotion: Calcualtes the total amount of items which are eligible for promotions.
        /// </summary>
        /// <param name="promotionItem"></param>
        /// <param name="listOfItemsEligibleForPromotion"></param>
        /// <returns></returns>
        private int CalculateAmountForPromotion(PromotionItem promotionItem, List<Item> listOfItemsEligibleForPromotion)
        {
            int totalAmount = 0;
            if (listOfItemsEligibleForPromotion != null && listOfItemsEligibleForPromotion.Count > 0)
            {
                bool isExists = listOfItemsEligibleForPromotion.Count == promotionItem.Items.Count;
                if (isExists)
                {
                    while (isExists)
                    {
                        totalAmount += promotionItem.Value;
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
