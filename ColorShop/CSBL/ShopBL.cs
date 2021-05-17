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

        public Customer AddUser(Customer customer)
        {
            if (_repo.GetUser(customer) != null)
            {
                throw new System.Exception("Restaurant already exists.");
            }
            return _repo.AddUser(customer);
        }

        public Customer GetUser(Customer customer)
        {
            return _repo.GetUser(customer);
        }

        public Customer DeleteUser(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}