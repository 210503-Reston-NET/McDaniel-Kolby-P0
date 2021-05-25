using System;
using Serilog;

namespace CSUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // logging function
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File("logs/myapp.txt", rollingInterval: RollingInterval.Day).CreateLogger();
            
            MenuFactory.GetMenu("welcome", null).Start();
        }
    }
}
