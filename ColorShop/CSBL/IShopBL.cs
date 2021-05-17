using System.Collections.Generic;
using CSModels;

namespace CSBL
{
    public interface IShopBL
    {
        List<Product> GetAllColors();

        List<Customer> GetAllUsers();
        Customer AddUser(Customer customer);
        Customer GetUser(Customer customer);
        Customer DeleteUser(Customer customer);


        List<Location> GetAllLocations();
    }
}