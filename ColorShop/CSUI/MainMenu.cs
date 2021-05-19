using System;
using System.Collections.Generic;
using CSModels;
using CSBL;

namespace CSUI
{
    public class MainMenu : IMenu
    {
        private IShopBL _shopBL;
        private Customer _user;
        public MainMenu(IShopBL shopBL)
        {
            _shopBL = shopBL;
        }
        public MainMenu(IShopBL shopBL, Customer user) : this(shopBL)
        {
            _user = user;
        }
        public void Start() 
        {
            bool repeat = true;
            
            do
            {
                Console.WriteLine("\nMain Menu");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Go to Store Menu");
                Console.WriteLine("[2] Go to Users Menu");
                Console.WriteLine("[3] Go to Products Menu");
                Console.WriteLine("[4] Access Manager Menu");
                Console.WriteLine("[0] Exit");
                //while (repeat)
                //{
                string input = Console.ReadLine();
                switch (input) 
                {
                    case "3":
                        MenuFactory.GetMenu("product", _user).Start();
                        break;
                    case "2":
                        MenuFactory.GetMenu("user", _user).Start();
                        break;
                    case "1":
                        MenuFactory.GetMenu("location", _user).Start();
                        break;
                    case "4":
                        // check if manager
                        //CheckManager();
                        Console.WriteLine("Error: Not yet Implemented");
                        break;
                    case "0":
                        Console.WriteLine("Exiting...");
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while(repeat);
        }

        private void CheckManager()
        {
            // if user is not a manager 
            // Console.WriteLine("Access prohibited. You are not on a manager account.");

            // else find location for manager.
            MenuFactory.GetMenu("manager", _user).Start();
        }

        
    }
}