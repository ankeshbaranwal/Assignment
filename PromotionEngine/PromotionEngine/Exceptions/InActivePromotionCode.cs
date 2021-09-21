using System;
using System.Collections.Generic;
using System.Text;


namespace PromotionEngine.Exceptions
{
    public class InActivePromotionCode : Exception
    {
        public InActivePromotionCode(string message) : base(message) { }
    }
}
