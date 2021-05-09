using System;

namespace CSUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu menu = new WelcomeMenu();
            menu.Start();
        }
    }
}
