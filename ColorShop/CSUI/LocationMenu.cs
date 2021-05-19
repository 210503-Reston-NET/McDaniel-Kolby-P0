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
                Console.WriteLine("\nStore Locations Menu");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Visit a store location");
                Console.WriteLine("[2] Search a store location");
                Console.WriteLine("[3] Add a location {manager access only}");
                Console.WriteLine("[4] Delete a location {manager access only}");
                Console.WriteLine("[5] View a location's order history");
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
                    case "3":
                        //CheckManager();
                        //AddALocation();
                        break;
                    case "4":
                        //CheckManager(); 
                        //DeleteALocation();
                        break;
                    case "5":
                        //ViewOrderHistory
                        break;
                    case "0":
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }

                
            }while(repeat);
        
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
                Console.WriteLine("Store locations: ");

                int i = 0;
                foreach (Location location in locations)
                {
                    Console.WriteLine("[" + ++i + "]" + location.ToString());
                }

                bool repeat = true;
                // TODO: Location inventory
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
                        else if(n <= locations.Count) 
                        {
                            Console.WriteLine("You chose " + locations[n - 1].City + ", " + locations[n - 1].State);
                            GetInventory(locations[n-1]);
                        }
                        else Console.WriteLine("invalid input");
                    }
                    else Console.WriteLine("invalid input");
                } while (repeat);
            }
        }

        private void GetInventory(Location location)
        {
            List<Stock> inventory = _shopBL.GetInventory(location);
        }
    }
}