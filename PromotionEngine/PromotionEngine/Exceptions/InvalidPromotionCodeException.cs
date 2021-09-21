using System;
using System.Collections.Generic;
using System.Text;


namespace PromotionEngine.Exceptions
{
    public class InvalidPromotionCodeException : Exception
    {
        public InvalidPromotionCodeException(string message) : base(message) { }
    }
}
