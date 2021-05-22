using CSModels;
using System.Collections.Generic;

namespace CSDL
{
    public interface IRepository
    {
        List<Product> GetAllColors();
        Product GetColor(Product product);
        Product AddColor(Product product);
        Product DeleteColor(Product product);

        List<Customer> GetAllUsers();
        Customer GetUser(Customer user);
        Customer GetUserName(Customer user);
        Customer AddUser(Customer user);
        Customer DeleteUser(Customer user);

        List<Location> GetAllLocations();
        Location GetLocation(Location location);
        Location AddLocation(Location location);
        Location DeleteLocation(Location location);

        List<Stock> GetInventory(int locationId);


        Order AddOrder(Order order);
        List<Order> GetAllOrders();

        LineItem AddLineItem(LineItem item);

        Stock AddStock(LineItem item, Location location, int quantity);
        Stock AddStock(Stock stock, Location location, int quantity);

        List<Order> GetLocationOrders(Location location, int sort);
        List<Order> GetUserOrders(Customer customer, int sort);

        Location CheckManager(Customer user);

        //Stock AddProduct(Location location, Product product, int quantity);
    }
}