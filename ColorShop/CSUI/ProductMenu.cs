using System;
using CSBL;
using CSModels;

namespace CSUI
{
    public class ProductMenu : IMenu
    {
        private IShopBL _shopBL;
        private Customer _user;
        public ProductMenu(IShopBL shopBL)
        {
            _shopBL = shopBL;
        }
        public ProductMenu(IShopBL shopBL, Customer user) : this(shopBL)
        {
            _user = user;
        }
        public void Start()
        {
            Console.WriteLine("\nProducts Menu");
            bool repeat = true;
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] View full selection of products");
                Console.WriteLine("[1] search a product");
                Console.WriteLine("[2] Exit");

                
            }while(repeat);
            throw new System.NotImplementedException();
        }
    }
}