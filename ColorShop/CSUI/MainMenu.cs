using System;
using System.Collections.Generic;
using CSModels;
using CSBL;

namespace CSUI
{
    public class MainMenu : IMenu
    {
        private IColorBL _colorBL;
        public MainMenu(IColorBL colorBL)
        {
            _colorBL = colorBL;
        }
        public void Start() {
            
            bool repeat = true;
            Console.WriteLine("Welcome to the Main Menu!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[0] Browse full selection of colors");
            Console.WriteLine("[1] Search users");
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
                        ViewColors();
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

        private void ViewColors()
        {
            List<Product> colors = _colorBL.GetAllColors();
            if (colors.Count == 0) Console.WriteLine("No products :< You should add some");
            else
            {
                foreach (Product color in colors)
                {
                    Console.WriteLine(color.ToString());
                }
            }
        }
    }
}