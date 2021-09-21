﻿using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine.Services
{
    public interface IPromotionService
    {
        /// <summary>
        /// GetPromotion
        /// </summary>
        /// <param name="promotionId"></param>
        /// <returns></returns>
        Promotion GetPromotion(string promotionId);
    }
}
