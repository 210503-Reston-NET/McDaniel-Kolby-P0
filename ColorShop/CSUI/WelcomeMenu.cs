using System;

namespace CSUI
{
    public class WelcomeMenu : IMenu
    {
        private IMenu mainMenu;
        public void Start()
        {
            bool repeat = true;
            Console.WriteLine("Welcome to Kolby's Color Shop Application!");
            Console.WriteLine("New user?");
            Console.WriteLine("[0] Yes");
            Console.WriteLine("[1] No");
            while (repeat) 
            {
                string input = Console.ReadLine();
                switch (input) 
                {
                    case "0":
                    case "yes":
                        Console.WriteLine("Sorry, that feature isn't implemented yes. Please choose the other option");
                        break;
                    case "1":
                    case "no":
                        repeat = false;
                        Console.WriteLine("Success! Logging in...");
                        MenuFactory.GetMenu("main").Start();
                        break;
                    default:
                        Console.WriteLine("Please input a valid option");
                        break;
                }
            } 
        }
    }
}