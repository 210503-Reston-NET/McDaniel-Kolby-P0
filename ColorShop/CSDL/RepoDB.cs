using System.Collections.Generic;
using Model = CSModels;
using Entity = CSDL.Entities;
using System.Linq;

namespace CSDL
{
    public class RepoDB : IRepository
    {
        private Entity.ComputerShopDBContext _context;
        public RepoDB(Entity.ComputerShopDBContext context)
        {
            _context = context;
        }
        public List<Model.Customer> GetAllUsers()
        {
            return _context.Customers
            .Select(
                user => new Model.Customer(user.Name, user.Username, user.Password)
            ).ToList();
        }
        public Model.Customer GetUser(Model.Customer user)
        {
            Entity.Customer found = _context.Customers.FirstOrDefault(customer => customer.Username == user.Username && customer.Password == user.Password);
            if (found == null) return null;
            return new Model.Customer(found.Name, found.Username, found.Password);
        }
        public Model.Customer AddUser(Model.Customer user)
        {
            _context.Customers.Add(
                new Entity.Customer{
                    Name = user.Name,
                    Username = user.Username,
                    Password = user.Password
                }
            );
            _context.SaveChanges();
            return user;
        }
        public Model.Customer DeleteUser(Model.Customer user)
        {
            throw new System.NotImplementedException();
        }

        public List<Model.Product> GetAllColors()
        {
            throw new System.NotImplementedException();
        }

        public List<Model.Location> GetAllLocations()
        {
            throw new System.NotImplementedException();
        }

        
    }
}