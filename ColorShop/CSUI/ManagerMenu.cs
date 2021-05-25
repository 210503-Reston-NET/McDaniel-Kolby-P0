using System;
using System.Collections.Generic;
using CSBL;
using CSModels;
using Serilog;

namespace CSUI
{
    public class ManagerMenu : IMenu
    {
        private IShopBL _shopBL;
        private Customer _user;
        public ManagerMenu(IShopBL shopBL)
        {
            _shopBL = shopBL;
        }
        public ManagerMenu(IShopBL shopBL, Customer user) : this(shopBL)
        {
            _user = user;
        }
        public void Start()
        {
            bool repeat = true;
            do
            {
                Console.WriteLine("\nManager Menu");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Replenish a product's stock at a store location");
                Console.WriteLine("[2] Add a store location {Not Implemented");
                Console.WriteLine("[3] Delete a store location {Not Implemented}");
                Console.WriteLine("[4] Add a product to database {Not Implemented}");
                Console.WriteLine("[5] Delete a product {Not Implemented}");
                Console.WriteLine("[0] Go back");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Log.Information("Selected to replenish inventory");
                        ViewLocations();
                        break;
                    case "2":
                        Console.WriteLine("Error: Not yet Implemented");
                        //AddALocation();
                        break;
                    case "3":
                        Console.WriteLine("Error: Not yet Implemented");
                        //DeleteALocation();
                        break;
                    case "4":
                        Console.WriteLine("Error: Not yet Implemented");
                        //AddAProduct();
                        break;
                    case "5":
                        Console.WriteLine("Error: Not yet Implemented");
                        //DeleteAProduct();
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

                Console.WriteLine("Choose which location's inventory you would like to replenish. Otherwise type [0] to go back.");


                do
                {
                    string input = Console.ReadLine();
                    int n;
                    if (int.TryParse(input, out n))
                    {
                        if (input == "0")
                        {
                            Console.WriteLine("Returning to Manager Menu...");
                            repeat = false;
                        }
                        else if (n <= locations.Count)
                        {
                            Log.Information($"Selected location {locations[n - 1].City}, {locations[n - 1].State}");
                            ReplenishInv(locations[n - 1]);
                            repeat = false;
                        }
                        else Console.WriteLine("invalid input");
                    }
                    else Console.WriteLine("invalid input");
                } while (repeat);
            }

        }

        private void ReplenishInv(Location location)
        {
            List<Stock> inventory = _shopBL.GetInventory(location);

            Console.WriteLine($"\nDisplaying Inventory to update at store located at {location.City}, {location.State}:");
            int i = 0;
            foreach (Stock stock in inventory)
            {
                Console.WriteLine("[" + ++i + "] " + stock.ToString());
            }

            bool repeat = true;
            do
            {
                Console.WriteLine("Select an item to replenish. Otherwise type [0] to go back.");

                string input = Console.ReadLine();
                int n;
                if (int.TryParse(input, out n))
                {
                    if (n == 0)
                    {
                        repeat = false;
                        return;
                    }
                    else if (n > 0 && n <= inventory.Count)
                    {
                        Log.Information($"Selected color {inventory[n - 1].Product.Name}");
                        bool repeat2 = true;
                        do
                        {

                            Console.WriteLine($"Input how much of color {inventory[n - 1].Product.Name} you would like to add? Otherwise type [0] to go back.");
                            string quantity = Console.ReadLine();
                            int num;
                            if (int.TryParse(quantity, out num))
                            {
                                if (num == 0)
                                {
                                    repeat2 = false;
                                    return;
                                }
                                if (num > 0)
                                {
                                    Log.Information($"Selected to add {num} of stock to inventory");
                                    // add to stock
                                    Stock addedStock = _shopBL.AddStock(inventory[n - 1], location, num);
                                    if (addedStock == null) Console.WriteLine("Inventory could not be updated. (Server side error)");
                                    else Console.WriteLine($"Successfully updated stock for color {inventory[n - 1].Product.Name}");
                                    return;
                                }
                            }
                            Console.WriteLine("Invalid input");
                        } while (repeat2);
                    }
                    else Console.WriteLine("Invalid input");
                }
                else Console.WriteLine("Invalid input");
            } while (repeat);
        }
    }
}