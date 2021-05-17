using CSModels;
using System.Collections.Generic;

namespace CSDL
{
    public interface IRepository
    {
        List<Product> GetAllColors();

        List<Customer> GetAllUsers();
        Customer GetUser(Customer user);
        Customer AddUser(Customer user);
        Customer DeleteUser(Customer user);

        List<Location> GetAllLocations();
    }
}