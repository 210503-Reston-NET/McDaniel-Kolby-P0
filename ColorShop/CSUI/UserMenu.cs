using System;
using System.Collections.Generic;
using CSBL;
using CSModels;

namespace CSUI
{
    public class UserMenu : IMenu
    {
        private IShopBL _shopBL;
        private Customer _user;
        public UserMenu(IShopBL shopBL)
        {
            _shopBL = shopBL;
        }
        public UserMenu(IShopBL shopBL, Customer user) : this(shopBL)
        {
            _user = user;
        }
        public void Start()
        {
            bool repeat = true;
            do
            {
                Console.WriteLine("\nUsers Menu");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] View full selection of users");
                Console.WriteLine("[2] Search a user");
                Console.WriteLine("[3] View your account");
                // TODO: delete an account
                Console.WriteLine("[4] Delete your account {Not Implemented}");
                Console.WriteLine("[0] Go back to Main Menu");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewUsers();
                        break;
                    case "2":
                        SearchUser();
                        break;
                    case "3":
                        Console.WriteLine("Account Information: \n");
                        Console.Write(_user.ToString());
                        break;
                    case "4": 
                        Console.WriteLine("Error: Not yet Implemented");
                        //DeleteAccount();
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

        private void DeleteAccount()
        {
            throw new NotImplementedException();
        }

        private void SearchUser()
        {
            Console.WriteLine("Enter the full name of the user you are looking for:");
            string name = Console.ReadLine();
            try
            {
                Customer foundUser = _shopBL.GetUserName(new Customer(name));
                Console.WriteLine("User found! \n");
                Console.Write(foundUser.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine($"User {name} not found.");
            }
        }

        private void ViewUsers()
        {
            List<Customer> users = _shopBL.GetAllUsers();
            if (users.Count == 0) Console.WriteLine("No users in database.");
            else 
            {
                Console.WriteLine("Full list of users: ");

                int i = 0;
                foreach (Customer user in users)
                {
                    Console.WriteLine("[" + ++i + "]" + user.ToString());
                }

                bool repeat = true;
                Console.WriteLine("Choose which account's order history you would like to view. Otherwise type [0] to go back.");
                do 
                {
                    string input = Console.ReadLine();
                    int n;
                    if (int.TryParse(input, out n))
                    {
                        if (input == "0")
                        {
                            Console.WriteLine("Returning to Users Menu...");
                            repeat = false;
                        }
                        else if(n <= users.Count) 
                        {
                            ViewOrderHistory(users[n - 1]);
                            repeat = false;
                        }
                        else Console.WriteLine("invalid input");
                    }
                    else Console.WriteLine("invalid input");
                } while (repeat);
            }
        }

        private void ViewOrderHistory(Customer customer)
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
                        Console.WriteLine($"\nOrder History for {customer.Name}:\n");
                        List<Order> history1 = _shopBL.GetUserOrders(customer, 1);
                        foreach(Order order in history1)
                        {
                            Console.WriteLine(order.ToStringHistoryDate());
                        }
                        repeat = false;
                        break;
                    case "2":
                        Console.WriteLine($"\nOrder History for {customer.Name}:\n");
                        List<Order> history2 = _shopBL.GetUserOrders(customer, 2);
                        foreach(Order order in history2)
                        {
                            Console.WriteLine(order.ToStringHistoryDate());
                        }
                        repeat = false;
                        break;
                    case "3":
                        Console.WriteLine($"\nOrder History for {customer.Name}:\n");
                        List<Order> history3 = _shopBL.GetUserOrders(customer, 3);
                        foreach(Order order in history3)
                        {
                            Console.WriteLine(order.ToStringHistoryCost());
                        }
                        repeat = false;
                        break;
                    case "4":
                        Console.WriteLine($"\nOrder History for {customer.Name}:\n");
                        List<Order> history4 = _shopBL.GetUserOrders(customer, 4);
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
    }
}