using System;
using System.Collections.Generic;
using System.Text;


namespace PromotionEngine.Exceptions
{
    public class PromotionEngineArgumentException : Exception
    {
        public PromotionEngineArgumentException(string message) : base(message) { }
    }
}
