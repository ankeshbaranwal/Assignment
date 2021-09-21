using NUnit.Framework;
using PromotionEngine.Models;
using PromotionEngine.Services;

namespace PromotionEngine.Tests
{
    public class PromotionServiceTest
    {

        private PromotionService promotionService;

        [SetUp]
        public void Setup()
        {
            promotionService = new PromotionService();

        }

        [Test]
        public void GetPromotion_Valid_PromotionId_Returns_Object()
        {
            var promotion = promotionService.GetPromotion("Promotion1");
            Assert.IsNotNull(promotion);

        }
        [Test]
        public void GetPromotion_InValid_PromotionId_Returns_Null()
        {
            var promotion = promotionService.GetPromotion("Promotion2");
            Assert.IsNull(promotion);

        }

    }
}