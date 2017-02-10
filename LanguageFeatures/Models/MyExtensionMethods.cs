// The purpose of this is to demonstrate using an extension method,
// which adds functionality to an accessable class that cannot be modified
// Assume that the total value of the Product objects in the ShoppingCart class is needed,
// and the class cannot be modified for whatever reason
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this /*ShoppingCart cartParam*/ IEnumerable<Product> productEnum)
        {
            decimal total = 0;
            foreach (Product prod in /*cartParam.Products*/ productEnum)
            {
                total += prod.Price;
            }
            return total;
        }
        public static IEnumerable<Product> FilterByCategory
            (this IEnumerable<Product> productEnum, string categoryParam)
        {
            foreach (Product prod in productEnum)
            {
                if (prod.Category == categoryParam)
                {
                    yield return prod;
                }
            }
        }
        public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnum, Func<Product, bool> selectorParam)
        {
            foreach (Product prod in productEnum)
            {
                if (selectorParam(prod))
                {
                    yield return prod;
                }
            }
        }
    }
}