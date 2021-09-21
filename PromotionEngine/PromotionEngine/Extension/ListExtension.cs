using PromotionEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PromotionEngine.Extension
{
    public static class ListExtensions
    {
        public static List<Item> GetClone(this List<Item> source)
        {
            return source.Select(item => new Item(item))
                    .ToList();
        }
    }
}
