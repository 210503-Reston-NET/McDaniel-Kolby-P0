using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using CSBL;
using CSModels;
using Serilog;

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
            var myLog = Log.ForContext<LocationMenu>();
            
            bool repeat = true;
            do
            {
                Console.WriteLine("\nStore Menu");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Make an order at a store location");
                Console.WriteLine("[2] Search a store location");
                Console.WriteLine("[3] View a location's order history");
                Console.WriteLine("[0] Go back to Main Menu");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Log.Information("Selected make an order");
                        ViewLocations(1);
                        break;
                    case "2":
                        Log.Information("Selected search a location");
                        SearchLocation();
                        break;
                    case "3":
                        Log.Information("Selected view order history");
                        ViewLocations(2);
                        break;
                    case "0":
                        Log.Information("Selected go back to main menu");
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }


            } while (repeat);

        }

        private void ViewOrderHistory(Location location)
        {
            Console.WriteLine("How would you like to sort the Order Histories?");
            Console.WriteLine("[1] Date (most recent to least recent)");
            Console.WriteLine("[2] Date (least recent to most recent)");
            Console.WriteLine("[3] Cost (most expensive to least expensive");
            Console.WriteLine("[4] Cost (least expensive to most expensive");
            Console.WriteLine("[5] Go back");
            bool repeat = true;
            do
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Log.Information("Selected to sort by date (most recent to least recent)");
                        Console.WriteLine($"\nOrder History for {location.City}, {location.State}:\n");
                        List<Order> history1 = _shopBL.GetLocationOrders(location, 1);
                        foreach(Order order in history1)
                        {
                            Console.WriteLine(order.ToStringHistoryDate());
                        }
                        repeat = false;
                        break;
                    case "2":
                        Log.Information("Selected to sort by date (least recent to most recent)");
                        Console.WriteLine($"\nOrder History for {location.City}, {location.State}:\n");
                        List<Order> history2 = _shopBL.GetLocationOrders(location, 2);
                        foreach(Order order in history2)
                        {
                            Console.WriteLine(order.ToStringHistoryDate());
                        }
                        repeat = false;
                        break;
                    case "3":
                        Log.Information("Selected to sort by cost (most expensive to least expensive)");
                        Console.WriteLine($"\nOrder History for {location.City}, {location.State}:\n");
                        List<Order> history3 = _shopBL.GetLocationOrders(location, 3);
                        foreach(Order order in history3)
                        {
                            Console.WriteLine(order.ToStringHistoryCost());
                        }
                        repeat = false;
                        break;
                    case "4":
                    Log.Information("Selected to sort by cost (least expensive to most expensive)");
                        Console.WriteLine($"\nOrder History for {location.City}, {location.State}:\n");
                        List<Order> history4 = _shopBL.GetLocationOrders(location, 4);
                        foreach(Order order in history4)
                        {
                            Console.WriteLine(order.ToStringHistoryCost());
                        }
                        repeat = false;
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("invalid input");
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
                Console.WriteLine("Store found! \n");
                Console.Write(foundLocation.ToString());
                Log.Information($"Successfully searched store at {foundLocation.City}, {foundLocation.State}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"There is no store at that location in the database.");
            }
        }

        private void ViewLocations(int option)
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

                if (option == 1)
                    Console.WriteLine("Choose which location's inventory you would like to view. Otherwise type [0] to go back.");
                else if (option == 2)
                    Console.WriteLine("Choose which location's order history you would like to view. Otherwise type [0] to go back.");

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
                        else if (n > 0 && n <= locations.Count)
                        {
                            Log.Information($"Selected location at {locations[n - 1].City}, {locations[n - 1].State}");
                            if (option == 1)
                                GetInventory(locations[n - 1]);
                            else if (option == 2)
                                ViewOrderHistory(locations[n - 1]);
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
                        Log.Information("Selected start a new order");
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
                    else if (n > 0 && n <= inventories.Count)
                    {
                        Log.Information($"Selected {inventories[n - 1].Product.Name}");
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
                                                Log.Information("Completed order");
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
            bool match = false;
            do
            {
                string input = Console.ReadLine();
                int n;
                if (int.TryParse(input, out n))
                {
                    // if items already in order
                    if (order.Total > 0.0)
                    {
                        //Case: Items already in order and there is a match with the input
                        foreach (LineItem item in order.LineItems)
                        {
                            if (item.Product.Equals(stock.Product))
                            {
                                match = true;
                                if (n == 0)
                                {
                                    repeat = false;
                                    return order;
                                }
                                else if ((n + item.Quantity) <= stock.Quantity)
                                {
                                    Log.Information($"Selected to add {n} products to order");
                                    Console.WriteLine($"Adding {n} of the product {stock.Product.Name} to your order...");
                                    item.Quantity = item.Quantity + n;
                                    double total = n * stock.Product.Price;
                                    order.Total = order.Total + total;
                                    Console.WriteLine("Successfully added! \n");
                                    return order;
                                }
                                else Console.WriteLine("Not enough in stock!");
                                break;
                            }
                        }
                    }
                    //Case: no matches
                    if (match == false)
                    {
                        if (n == 0)
                        {
                            repeat = false;
                            return order;
                        }
                        else if (n <= stock.Quantity)
                        {
                            Log.Information($"Selected to add {n} products to order");
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
                }
                else Console.WriteLine("invalid input");
            } while (repeat);
            return order;
        }
    }
}