using System.Collections.Generic;
using CSModels;
using CSDL;

namespace CSBL
{
    public class ShopBL : IShopBL
    {
        private IRepository _repo;
        public ShopBL(IRepository repo)
        {
            _repo = repo;
        }
        public List<Product> GetAllColors()
        {
            return _repo.GetAllColors();
        }
        public List<Customer> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }
        public List<Location> GetAllLocations()
        {
            return _repo.GetAllLocations();
        }
    }
}