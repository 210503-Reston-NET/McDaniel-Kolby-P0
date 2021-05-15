using System;

namespace CSUI
{
    public class ManagerMenu : IMenu
    {
        public void Start()
        {
            Console.WriteLine("Welcome to the Manager's Menu.");
            bool repeat = true;
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] Replensih inventory");
                Console.WriteLine("[1] Go back");

                string input = Console.ReadLine();
                switch (input) 
                {
                    case "0":
                        Console.WriteLine("Replenish Inventories");
                        ReplenishInv();
                        break;
                    case "1":
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (repeat);
        }

        private void ReplenishInv()
        {
            Console.WriteLine("Choose a location");
            Console.ReadLine();
            Console.WriteLine("Choose a product to restock");
            Console.ReadLine();
            Console.WriteLine("Inventory replenished");

        }
    }
}