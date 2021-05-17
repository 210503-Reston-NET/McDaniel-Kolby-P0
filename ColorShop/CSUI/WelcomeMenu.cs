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
            Console.WriteLine("Welcome to The Colorful Shop Online!");
            while (repeat) 
            {
                Console.WriteLine("New user?");
                Console.WriteLine("[1] Yes");
                Console.WriteLine("[2] No");
                Console.WriteLine("[0] Exit");
                string input = Console.ReadLine();
                switch (input) 
                {
                    case "1":
                    case "yes":
                        if (!AddAUser())
                            break;
                        repeat = false;
                        mainMenu = MenuFactory.GetMenu("main", _user);
                        mainMenu.Start();
                        break;
                    case "2":
                    case "no":
                        if (!Login())
                            break;
                        repeat = false;
                        mainMenu = MenuFactory.GetMenu("main", _user);
                        mainMenu.Start();
                        break;
                    case "0":
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Please input a valid option");
                        break;
                }
            } 
        }

        private bool Login()
        {
            Console.WriteLine("Enter your username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter your password: ");
            string password = Console.ReadLine();

            Customer credentials = new Customer(username, password);
            Customer found = _shopBL.GetUser(credentials);
            if (found == null)
            {
                Console.WriteLine("Incorrect username/password.");
                return false;
            }
            else 
            {
                Console.WriteLine($"\nWelcome {found.Name}! Logging in...");
                _user = found;
                return true;
            }
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