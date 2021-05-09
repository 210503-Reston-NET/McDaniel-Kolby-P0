using System;

namespace CSUI
{
    public class MainMenu : IMenu
    {
        public void Start() {
            
            bool repeat = true;
            Console.WriteLine("Welcome to the Main Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[0] Browse full selection of products");
            Console.WriteLine("[1] Browse users");
            Console.WriteLine("[2] See store locations");
            Console.WriteLine("[3] View cart");
            Console.WriteLine("[4] Exit");
            while (repeat)
            {
                string input = Console.ReadLine();
                switch (input) 
                {
                    case "0":
                        Console.WriteLine("Selected \"Browse full selection\"...");
                        break;
                    case "1":
                        Console.WriteLine("Selected \"Browse users\"...");
                        break;
                    case "2":
                        Console.WriteLine("Selected \"See store locations\"...");
                        break;
                    case "3":
                        Console.WriteLine("Selected \"View cart\"");
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}