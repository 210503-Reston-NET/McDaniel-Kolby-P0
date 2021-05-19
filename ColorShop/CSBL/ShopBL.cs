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


        // Products database calls
        public List<Product> GetAllColors()
        {
            return _repo.GetAllColors();
        }
        public Product GetColor(Product product)
        {
            return _repo.GetColor(product);
        }
        public Product AddColor(Product product)
        {
            if (_repo.GetColor(product) != null)
            {
                throw new System.Exception($"The color {product.Name} already exists in the database.");
            }
            return _repo.AddColor(product);
        }
        public Product DeleteColor(Product product)
        {
            throw new System.NotImplementedException();
        }


        // Users database calls
        public List<Customer> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }
        public Customer GetUser(Customer customer)
        {
            return _repo.GetUser(customer);
        }
        public Customer GetUserName(Customer customer)
        {
            return _repo.GetUserName(customer);
        }   
        public Customer AddUser(Customer customer)
        {
            if (_repo.GetUser(customer) != null)
            {
                throw new System.Exception($"The account {customer.Username} already exists.");
            }
            return _repo.AddUser(customer);
        }
        public Customer DeleteUser(Customer customer)
        {
            throw new System.NotImplementedException();
        }


        // Locations database calls
        public List<Location> GetAllLocations()
        {
            return _repo.GetAllLocations();
        }
        public Location GetLocation(Location location)
        {
            return _repo.GetLocation(location);
        }
        public Location AddLocation(Location location)
        {
            if (_repo.GetLocation(location) != null)
            {
                throw new System.Exception($"The Location {location.City}, {location.State} already exists in the database.");
            }
            return _repo.AddLocation(location);
        }
        public Location DeleteLocation(Location location)
        {
            throw new System.NotImplementedException();
        }


        // Inventory
        public List<Stock> GetInventory(Location location)
        {
            int locationId = location.Id;
            return _repo.GetInventory(locationId);
        }

        /*
        
        public Order AddOrder(Order order)
        {
            return _repo.AddOrder(order);
        }
        */
        public List<Order> GetAllOrders()
        {
            return _repo.GetAllOrders();
        }

        
    }
}