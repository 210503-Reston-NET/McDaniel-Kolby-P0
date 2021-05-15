using System.Collections.Generic;
using CSModels;

namespace CSDL
{
    public class CSStaticColl
    {
        public static List<Product> Colors = new List<Product>()
        {
            new Product("Red", 10.00, "The color of tomatoes")
        };
    }
}