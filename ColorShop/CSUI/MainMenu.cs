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
                Console.WriteLine("[1] Go to Products Menu");
                Console.WriteLine("[2] Go to Users Menu");
                Console.WriteLine("[3] Go to Locations Menu");
                Console.WriteLine("[4] View cart");
                Console.WriteLine("[5] Access Manager Menu");
                Console.WriteLine("[0] Exit");
                //while (repeat)
                //{
                string input = Console.ReadLine();
                switch (input) 
                {
                    case "1":
                        MenuFactory.GetMenu("product", _user).Start();
                        break;
                    case "2":
                        MenuFactory.GetMenu("user", _user).Start();
                        break;
                    case "3":
                        //Console.WriteLine("Store Locations:");
                        //ViewLocations();
                        MenuFactory.GetMenu("location", _user).Start();
                        break;
                    case "4":
                        Console.WriteLine("Selected \"View cart\"");
                        break;
                    case "5":
                        // check if manager
                        //CheckManager();
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

        private void ViewLocations()
        {
            int i = 0;
            List<Location> locations = _shopBL.GetAllLocations();
            if (locations.Count == 0) Console.WriteLine("No locations. You should add some.");
            else 
            {
                foreach (Location location in locations)
                {
                    Console.WriteLine("[" + ++i + "]" + location.ToString());
                }

                bool repeat = true;
                Console.WriteLine("Choose which Location you would like to visit. Otherwise type [0] to go back.");
                do
                {
                    string input = Console.ReadLine();
                    int n;
                    if (int.TryParse(input, out n))
                    {
                        if (n == 0)
                        {
                            Console.WriteLine("Returning to main menu...");
                            repeat = false;
                        }
                        else if(n <= locations.Count)
                        {
                            Console.WriteLine("You chose " + locations[n - 1].City + ", " + locations[n - 1].State);
                            // go to location menu
                        }
                        else Console.WriteLine("invalid input");
                    }
                    else Console.WriteLine("invalid input");
                } while(repeat);
            }
        }

        
    }
}