using System.IO;
using CSDL;
using CSBL;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Entity = CSDL.Entities;
using Model = CSModels;

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

            switch (menuType.ToLower())
            {
                case "welcome":
                    return new WelcomeMenu(new ShopBL(new RepoDB(context)));
                case "main":
                    return new MainMenu(new ShopBL(new RepoDB(context)), user);
                case "manager":
                    return new ManagerMenu(new ShopBL(new RepoDB(context)), user);
                case "product":
                    return new ProductMenu(new ShopBL(new RepoDB(context)), user);
                case "user":
                    return new UserMenu(new ShopBL(new RepoDB(context)), user);
                case "location":
                    return new LocationMenu(new ShopBL(new RepoDB(context)), user);
                default:
                    return null;
            }
        }

    }
}