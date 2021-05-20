using System.Collections.Generic;
using CSModels;

namespace CSBL
{
    public interface IShopBL
    {
        List<Product> GetAllColors();
        Product GetColor(Product product);
        Product AddColor(Product product);
        Product DeleteColor(Product product);


        List<Customer> GetAllUsers();
        Customer GetUser(Customer customer);
        Customer GetUserName(Customer user);
        Customer AddUser(Customer customer);
        Customer DeleteUser(Customer customer);


        List<Location> GetAllLocations();
        Location GetLocation(Location location);
        Location AddLocation(Location location);
        Location DeleteLocation(Location location);


        List<Stock> GetInventory(Location location);


        Order AddOrder(Order order);
        List<Order> GetAllOrders();
    }
}