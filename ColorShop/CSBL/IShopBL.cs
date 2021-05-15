using System.Collections.Generic;
using CSModels;

namespace CSBL
{
    public interface IShopBL
    {
        List<Product> GetAllColors();
        List<Customer> GetAllUsers();
        List<Location> GetAllLocations();
    }
}