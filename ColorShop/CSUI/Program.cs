using System;

namespace CSUI
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuFactory.GetMenu("welcome", null).Start();
        }
    }
}
