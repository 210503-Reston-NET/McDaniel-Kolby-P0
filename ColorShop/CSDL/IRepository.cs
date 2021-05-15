using CSModels;
using System.Collections.Generic;

namespace CSDL
{
    public interface IRepository
    {
         List<Product> GetAllColors();
         List<Customer> GetAllUsers();
         List<Location> GetAllLocations();
    }
}