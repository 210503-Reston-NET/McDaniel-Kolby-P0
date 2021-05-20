using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using CSBL;
using CSModels;

namespace CSUI
{
    public class LocationMenu : IMenu
    {
        private IShopBL _shopBL;
        private Customer _user;
        public LocationMenu(IShopBL shopBL)
        {
            _shopBL = shopBL;
        }
        public LocationMenu(IShopBL shopBL, Customer user) : this(shopBL)
        {
            _user = user;
        }
        public void Start()
        {
            bool repeat = true;
            do
            {
                Console.WriteLine("\nStore Menu");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Visit a store location");
                Console.WriteLine("[2] Search a store location");
                Console.WriteLine("[3] View a location's order history");
                Console.WriteLine("[4] Add a location {manager access only}");
                Console.WriteLine("[5] Delete a location {manager access only}");
                Console.WriteLine("[6] Replenish inventory at a store location {manager access only}");

                Console.WriteLine("[0] Go back to Main Menu");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewLocations();
                        break;
                    case "2":
                        SearchLocation();
                        break;
                    case "4":
                        //CheckManager();
                        //AddALocation();
                        Console.WriteLine("Error: Not yet Implemented");
                        break;
                    case "5":
                        //CheckManager(); 
                        //DeleteALocation();
                        Console.WriteLine("Error: Not yet Implemented");
                        break;
                    case "3":
                        //ViewOrderHistory
                        Console.WriteLine("Error: Not yet Implemented");
                        break;
                    case "6":
                        //CheckManager();
                        //ReplenishInventory();
                        Console.WriteLine("Error: Not yet Implemented");
                        break;
                    case "0":
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }


            } while (repeat);

        }

        private void SearchLocation()
        {
            Console.WriteLine("Enter the city of the location you would like to search: ");
            string city = Console.ReadLine();
            Console.WriteLine("Enter the state of the location you would like to search: ");
            string state = Console.ReadLine();
            try
            {
                Location foundLocation = _shopBL.GetLocation(new Location(city, state));
                Console.WriteLine(foundLocation.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"There is no store at that location in the database.");
            }
        }

        private void ViewLocations()
        {
            List<Location> locations = _shopBL.GetAllLocations();
            if (locations.Count == 0) Console.WriteLine("No locations in database. You should add some.");
            else
            {
                Console.WriteLine("\nStore locations: ");

                int i = 0;
                foreach (Location location in locations)
                {
                    Console.WriteLine("[" + ++i + "] " + location.ToString());
                }

                bool repeat = true;
                Console.WriteLine("Choose which location's inventory you would like to view. Otherwise type [0] to go back.");
                do
                {
                    string input = Console.ReadLine();
                    int n;
                    if (int.TryParse(input, out n))
                    {
                        if (input == "0")
                        {
                            Console.WriteLine("Returning to Locations Menu...");
                            repeat = false;
                        }
                        else if (n <= locations.Count)
                        {
                            GetInventory(locations[n - 1]);
                            repeat = false;
                        }
                        else Console.WriteLine("invalid input");
                    }
                    else Console.WriteLine("invalid input");
                } while (repeat);
            }
        }

        private void GetInventory(Location location)
        {

            List<Stock> inventories = _shopBL.GetInventory(location);

            bool repeat = true;

            Console.WriteLine($"\nDisplaying inventory of Store located at {location.City}, {location.State}:");
            int i = 0;
            foreach (Stock stock in inventories)
            {
                Console.WriteLine("[" + ++i + "] " + stock.ToString());
            }


            Console.WriteLine("Would you like to start a new order at this store?");
            Console.WriteLine("[1] yes");
            Console.WriteLine("[2] no");
            bool repeat2 = true;
            do
            {
                string input2 = Console.ReadLine();
                switch (input2)
                {
                    case "yes":
                    case "1":

                        repeat2 = false;
                        break;
                    case "no":
                    case "2":
                        repeat2 = false;
                        repeat = false;
                        return;
                    default:
                        Console.WriteLine("invalid input");
                        break;
                }
            } while (repeat2);

            Order newOrder = new Order(_user, location, 0.0, DateTime.Now);

            do
            {
                Console.WriteLine("Select an item to add to your order. Otherwise type [0] to go back.");

                string input = Console.ReadLine();
                int n;
                if (int.TryParse(input, out n))
                {
                    if (input == "0")
                    {
                        Console.WriteLine("Returning to Locations Menu...");
                        repeat = false;
                    }
                    else if (n <= inventories.Count)
                    {

                        newOrder = AddToOrder(inventories[n - 1], newOrder);


                        bool repeat3 = true;
                        do
                        {
                            Console.WriteLine("Would you like to add another item to your order?");
                            Console.WriteLine("[1] Add more items");
                            Console.WriteLine("[2] View Order and checkout");
                            Console.WriteLine("[0] Exit (you will lose your order)");
                            string input2 = Console.ReadLine();
                            switch (input2)
                            {
                                case "1":
                                    repeat3 = false;
                                    break;
                                case "2":
                                    Console.WriteLine();
                                    Console.WriteLine(newOrder.ToString());
                                    Console.WriteLine("Would you like to check out and complete your order?");
                                    Console.WriteLine("[1] yes, check out");
                                    Console.WriteLine("[2] no, go back");

                                    bool repeat4 = true;
                                    do
                                    {
                                        string input4 = Console.ReadLine();
                                        switch (input4)
                                        {
                                            case "1":
                                            case "yes":
                                                Order addedOrder = _shopBL.AddOrder(newOrder);
                                                Console.WriteLine("Order completed!");
                                                repeat = false;
                                                repeat3 = false;
                                                repeat4 = false;
                                                break;
                                            case "2":
                                            case "no":
                                                repeat4 = false;
                                                break;
                                            default:
                                                Console.WriteLine("invalid input");
                                                break;
                                        }
                                    } while (repeat4);
                                    break;
                                case "0":
                                    repeat3 = false;
                                    repeat = false;
                                    break;
                                default:
                                    Console.WriteLine("invalid input");
                                    break;
                            }
                        } while (repeat3);

                    }
                    else Console.WriteLine("invalid input");
                }
                else Console.WriteLine("invalid input");
            } while (repeat);
        }


        private Order AddToOrder(Stock stock, Order order)
        {
            Console.WriteLine($"You chose {stock.Product.Name}.");
            Console.WriteLine("Input how many you would like to add to your order. Type [0] to go back.");
            bool repeat = true;
            do
            {
                string input = Console.ReadLine();
                int n;
                int quantity = 0;
                if (order.Total > 0.0)
                {
                    foreach (LineItem item in order.LineItems)
                    {
                        if (item.Product.Equals(stock.Product))
                        {
                            quantity = item.Quantity;
                            break;
                        }
                    }
                }
                if (int.TryParse(input, out n))
                {
                    if (input == "0")
                    {
                        repeat = false;
                        return order;
                    }
                    else if ((n + quantity) <= stock.Quantity)
                    {
                        Console.WriteLine($"Adding {n} of the product {stock.Product.Name} to your order...");

                        double total = n * stock.Product.Price;
                        order.Total = order.Total + total;
                        LineItem newLineItem = new LineItem(order, stock.Product, n);
                        order.LineItems.Add(newLineItem);
                        //LineItem addedLineItem = _shopBL.AddLineItem(newLineItem);
                        Console.WriteLine("successfully added!");
                        return order;

                    }
                    else Console.WriteLine("Not enough in stock!");
                }
                else Console.WriteLine("invalid input");
            } while (repeat);
            return order;
        }
    }
}