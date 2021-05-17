using System;
using CSBL;
using CSModels;

namespace CSUI
{
    public class WelcomeMenu : IMenu
    {
        private IShopBL _shopBL;
        private IMenu mainMenu;
        private Customer _user;

        public WelcomeMenu(IShopBL shopBL)
        {
            _shopBL = shopBL;
        }
        public void Start()
        {
            bool repeat = true;
            Console.WriteLine("Welcome to Kolby's Color Shop Application!");
            Console.WriteLine("New user?");
            Console.WriteLine("[0] Yes");
            Console.WriteLine("[1] No");
            Console.WriteLine("[2] Exit");
            while (repeat) 
            {
                string input = Console.ReadLine();
                switch (input) 
                {
                    case "0":
                    case "yes":
                        bool success = false;
                        while(!success)
                        {
                            success = AddAUser();
                        }
                        repeat = false;
                        mainMenu = MenuFactory.GetMenu("main", _user);
                        mainMenu.Start();
                        break;
                    case "1":
                    case "no":
                        Login();
                        repeat = false;
                        mainMenu = MenuFactory.GetMenu("main", _user);
                        mainMenu.Start();
                        break;
                    case "2":
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Please input a valid option");
                        break;
                }
            } 
        }

        private void Login()
        {
            bool repeat = true;
            do
            {
                Console.WriteLine("Enter your username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Enter your password: ");
                string password = Console.ReadLine();

                Customer credentials = new Customer(username, password);
                Customer found = _shopBL.GetUser(credentials);
                if (found == null)
                {
                    Console.WriteLine("Incorrect username/password. Please try again");
                }
                else 
                {
                    Console.WriteLine($"\nWelcome {found.Name}! Logging in...");
                    _user = found;
                    repeat = false;
                }
            } while(repeat);
        }

        private bool AddAUser()
        {
            Console.WriteLine("Create a new account");
            Console.WriteLine("Enter your full name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter a password for this account: ");
            string password = Console.ReadLine();
            
            bool repeat = true;
            do{
                Console.WriteLine("Please re-enter your password: ");
                string password2 = Console.ReadLine();
                if (password == password2) repeat = false;
                else Console.WriteLine("password does not match");
            } while(repeat);

            try
            {
                Customer newUser = new Customer(name, username, password);
                Customer createdUser = _shopBL.AddUser(newUser);
                Console.WriteLine("New account created! Logging in... \n");
                Console.WriteLine(createdUser.ToString());
                _user = createdUser;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;

        }
    }
}