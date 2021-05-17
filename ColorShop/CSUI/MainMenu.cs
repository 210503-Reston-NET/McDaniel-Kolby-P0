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
            Console.WriteLine("\nMain Menu");
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] Go to Products Menu");
                Console.WriteLine("[1] Go to Users Menu");
                Console.WriteLine("[2] Go to StoreFront Menu");
                Console.WriteLine("[3] View cart");
                Console.WriteLine("[4] Access Manager Menu");
                Console.WriteLine("[5] Exit");
                //while (repeat)
                //{
                string input = Console.ReadLine();
                switch (input) 
                {
                    case "0":
                        Console.WriteLine("Full selection: ");
                        ViewColors();
                        MenuFactory.GetMenu("product", _user).Start();
                        break;
                    case "1":
                        Console.WriteLine("Users: ");
                        ViewUsers();
                        MenuFactory.GetMenu("user", _user).Start();
                        break;
                    case "2":
                        Console.WriteLine("Store Locations:");
                        ViewLocations();
                        MenuFactory.GetMenu("location", _user).Start();
                        break;
                    case "3":
                        Console.WriteLine("Selected \"View cart\"");
                        break;
                    case "4":
                        // check if manager
                        CheckManager();
                        break;
                    case "5":
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

        private void ViewUsers()
        {
            int i = 0;
            List<Customer> users = _shopBL.GetAllUsers();
            if (users.Count == 0) Console.WriteLine("No users. You should add some.");
            else 
            {
                foreach (Customer user in users)
                {
                    Console.WriteLine("[" + ++i + "]" + user.ToString());
                }

                bool repeat = true;
                Console.WriteLine("Choose which Customer page you would like to visit. Otherwise type [0] to go back.");
                do 
                {
                    string input = Console.ReadLine();
                    int n;
                    if (int.TryParse(input, out n))
                    {
                        if (input == "0")
                        {
                            Console.WriteLine("Returning to main menu...");
                            repeat = false;
                        }
                        else if(n <= users.Count) 
                        {
                            Console.WriteLine("You chose " + users[n - 1].Name);
                            // go to customer menu
                        }
                        else Console.WriteLine("invalid input");
                    }
                    else Console.WriteLine("invalid input");
                } while (repeat);
            }
        }

        private void ViewColors()
        {
            int i = 0;
            List<Product> colors = _shopBL.GetAllColors();
            if (colors.Count == 0) Console.WriteLine("No products. You should add some.");
            else
            {
                foreach (Product color in colors)
                {
                    Console.WriteLine("[" + ++i + "]" + color.ToString());
                }

                bool repeat = true;
                Console.WriteLine("Choose which Product you would like to purchase. Otherwise type [0] to go back.");
                do
                {
                    string input = Console.ReadLine();
                    int n;
                    if (int.TryParse(input, out n))
                    {
                        if (input == "0")
                        {
                            Console.WriteLine("Returning to main menu...");
                            repeat = false;
                        }
                        else if (n <= colors.Count) 
                        {
                            Console.WriteLine("You chose " + colors[n - 1].Name);
                            // go to product menu
                        }
                        else Console.WriteLine("invalid input");
                    }
                    else Console.WriteLine("invalid input");
                } while(repeat);
            }
        }
    }
}