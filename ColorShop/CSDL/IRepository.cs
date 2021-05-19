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
        Customer AddUser(Customer user);
        Customer DeleteUser(Customer user);

        List<Location> GetAllLocations();
        Location GetLocation(Location location);
        Location AddLocation(Location location);
        Location DeleteLocation(Location location);

        List<Stock> GetInventory(int locationId);
    }
}