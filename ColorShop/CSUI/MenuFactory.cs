using System.IO;
using CSDL;
using CSBL;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Entity = CSDL.Entities;
using Model = CSModels;
using Serilog;

namespace CSUI
{
    public class MenuFactory
    {
        public static IMenu GetMenu(string menuType, Model.Customer user)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            // setting up db context
            string connectionString = configuration.GetConnectionString("ComputerShopDB");
            DbContextOptions<Entity.ComputerShopDBContext> options = new DbContextOptionsBuilder<Entity.ComputerShopDBContext>()
            .UseSqlServer(connectionString)
            .Options;

            var context = new Entity.ComputerShopDBContext(options);

            var myLog = Log.ForContext<MenuFactory>();

            switch (menuType.ToLower())
            {
                case "welcome":
                    myLog.Information("Accessing welcome menu");
                    return new WelcomeMenu(new ShopBL(new RepoDB(context)));
                case "main":
                    myLog.Information("Accessing main menu");
                    return new MainMenu(new ShopBL(new RepoDB(context)), user);
                case "manager":
                    myLog.Information("Accessing manager menu");
                    return new ManagerMenu(new ShopBL(new RepoDB(context)), user);
                case "user":
                    myLog.Information("Accessing user menu");
                    return new UserMenu(new ShopBL(new RepoDB(context)), user);
                case "location":
                    myLog.Information("Accessing store menu");
                    return new LocationMenu(new ShopBL(new RepoDB(context)), user);
                default:
                    return null;
            }
        }

    }
}