using System;
using System.Collections.Generic;
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
            
            bool repeat = true;
            do
            {
                Console.WriteLine("\nProducts Menu");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] View full selection of products");
                Console.WriteLine("[2] Search a product");
                Console.WriteLine("[3] Add a product {manager access only}");
                Console.WriteLine("[4] Delete a product {manager access only}");
                Console.WriteLine("[0] Go back to Main Menu");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewColors();
                        break;
                    case "2":
                        SearchProduct();
                        break;
                    case "3":
                        // if (CheckManager()) 
                        //  AddProduct();
                        Console.WriteLine("Error: Not yet Implemented");
                        break;
                    case "4": 
                        // if (CheckManager())
                        //  DeleteProduct();
                        Console.WriteLine("Error: Not yet Implemented");
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

        private void AddProduct()
        {
            throw new NotImplementedException();
        }

        private void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        private void SearchProduct()
        {
            Console.WriteLine("Enter the name of the color you are looking for:");
            string name = Console.ReadLine();
            try
            {
                Product foundProduct = _shopBL.GetColor(new Product(name));
                Console.WriteLine(foundProduct.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"Color {name} not found. You can add it to the database");
            }
        }

        private void ViewColors()
        {
            
            List<Product> colors = _shopBL.GetAllColors();

            if (colors.Count == 0) Console.WriteLine("No products in database. You should add some.");
            else
            {
                Console.WriteLine("Full selection: ");

                int i = 0;
                foreach (Product color in colors)
                {
                    Console.WriteLine("[" + ++i + "]" + color.ToString());
                }

                bool repeat = true;
                // TODO: add to cart
                Console.WriteLine("Choose which Product you would like to add to cart. Otherwise type [0] to go back.");
                do
                {
                    string input = Console.ReadLine();
                    int n;
                    if (int.TryParse(input, out n))
                    {
                        if (input == "0")
                        {
                            Console.WriteLine("Returning to Products Menu...");
                            repeat = false;
                        }
                        else if (n <= colors.Count) 
                        {
                            Console.WriteLine("You chose " + colors[n - 1].Name);
                            // add to cart here
                        }
                        else Console.WriteLine("invalid input");
                    }
                    else Console.WriteLine("invalid input");
                } while(repeat);
            }
        }
    }
}