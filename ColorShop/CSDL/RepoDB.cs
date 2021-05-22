using System.Net.Http.Headers;
using System.Dynamic;
using System.Collections.Generic;
using Model = CSModels;
using Entity = CSDL.Entities;
using System.Linq;
using CSModels;
using System;

namespace CSDL
{
    public class RepoDB : IRepository
    {
        private Entity.ComputerShopDBContext _context;
        public RepoDB(Entity.ComputerShopDBContext context)
        {
            _context = context;
        }

        // Users database calls
        public List<Model.Customer> GetAllUsers()
        {
            return _context.Customers
            .Select(
                user => new Model.Customer(user.Id, user.Name, user.Username, user.Password)
            ).ToList();
        }
        public Model.Customer GetUser(Model.Customer customer)
        {
            Entity.Customer found = _context.Customers.FirstOrDefault(user => user.Username == customer.Username && user.Password == customer.Password);
            if (found == null) return null;
            return new Model.Customer(found.Id, found.Name, found.Username, found.Password);
        }
        public Model.Customer GetUserName(Model.Customer customer)
        {
            Entity.Customer found = _context.Customers.FirstOrDefault(user => user.Name == customer.Name);
            if (found == null) return null;
            return new Model.Customer(found.Name, found.Username, found.Password);
        }
        public Model.Customer AddUser(Model.Customer customer)
        {
            _context.Customers.Add(
                new Entity.Customer
                {
                    Name = customer.Name,
                    Username = customer.Username,
                    Password = customer.Password
                }
            );
            _context.SaveChanges();
            return customer;
        }
        public Model.Customer DeleteUser(Model.Customer customer)
        {
            throw new System.NotImplementedException();
        }


        // Products database calls
        public List<Model.Product> GetAllColors()
        {
            return _context.Products
            .Select(
                color => new Model.Product(color.Name, color.Price, color.Description)
            ).ToList();
        }
        public Model.Product GetColor(Model.Product product)
        {
            Entity.Product found = _context.Products.FirstOrDefault(color => color.Name == product.Name);
            if (found == null) return null;
            return new Model.Product(found.Id, found.Name, found.Price, found.Description);
        }
        public Model.Product AddColor(Model.Product product)
        {
            _context.Products.Add(
                new Entity.Product
                {
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description
                }
            );
            _context.SaveChanges();
            return product;
        }
        public Model.Product DeleteColor(Model.Product product)
        {
            throw new System.NotImplementedException();
        }


        // Locations database calls
        public List<Model.Location> GetAllLocations()
        {
            return _context.Locations
            .Select(
                loc => new Model.Location(loc.Id, loc.City, loc.State, new Model.Customer(_context.Customers.FirstOrDefault(id => id.Id == loc.Manager).Name))
            ).ToList();
        }
        public Model.Location GetLocation(Model.Location location)
        {
            Entity.Location found = _context.Locations.FirstOrDefault(loc => loc.City == location.City && loc.State == location.State);
            if (found == null) return null;
            Entity.Customer foundManager = _context.Customers.FirstOrDefault(id => id.Id == found.Manager);
            return new Model.Location(found.Id, found.City, found.State, new Model.Customer(foundManager.Name, foundManager.Username, foundManager.Password));
        }
        public Model.Location AddLocation(Model.Location location)
        {
            _context.Locations.Add(
                new Entity.Location
                {
                    City = location.City,
                    State = location.State,
                    Manager = GetUser(location.Manager).Id
                }
            );
            _context.SaveChanges();
            return location;
        }
        public Model.Location DeleteLocation(Model.Location location)
        {
            throw new System.NotImplementedException();
        }


        // Get inventory call
        public List<Model.Stock> GetInventory(int locationId)
        {
            return _context.Stocks.Where(product => product.Location == locationId).Select(
                stock => new Model.Stock(
                    new Model.Product(_context.Products.FirstOrDefault(color => color.Id == stock.Product).Name,
                        _context.Products.FirstOrDefault(color => color.Id == stock.Product).Price,
                        _context.Products.FirstOrDefault(color => color.Id == stock.Product).Description),
                    new Model.Location(_context.Locations.FirstOrDefault(loc => loc.Id == stock.Location).City,
                        _context.Locations.FirstOrDefault(loc => loc.Id == stock.Location).State),
                    stock.Quantity)
            ).ToList();
        }


        // whhy is this bugging? cannot figure this part out for the life of me
        // some kind of scaffolding error i believe

        public Model.Order AddOrder(Model.Order order)
        {
            _context.Orders.Add(
                new Entity.Order
                {
                    Customer = order.Customer.Id,
                    Location = order.Location.Id,
                    Total = order.Total,
                    Time = order.Time
                }
            );
            _context.SaveChanges();
            return order;
        }

        public List<Model.Order> GetAllOrders()
        {
            return _context.Orders
            .Select(
                ord => new Model.Order(
                    new Model.Customer(_context.Customers.FirstOrDefault(id => id.Id == ord.Customer).Name),
                    new Model.Location(_context.Locations.FirstOrDefault(id => id.Id == ord.Location).City, _context.Locations.FirstOrDefault(id => id.Id == ord.Location).State),
                    ord.Total,
                    ord.Time)
            ).ToList();
        }
        public Model.Order GetOrder(Model.Order order)
        {
            Entity.Order found = _context.Orders.FirstOrDefault(ord => ord.Time == order.Time && ord.Customer == order.Customer.Id && ord.Location == GetLocation(order.Location).Id);
            if (found == null) return null;
            //Entity.Order foundManager = _context.Customers.FirstOrDefault(id => id.Id == found.Manager);
            return new Model.Order(found.Id, order.Customer, order.Location, found.Total, found.Time);
            //new Model.Customer(foundManager.Name, foundManager.Username, foundManager.Password)
        }

        public Model.LineItem AddLineItem(Model.LineItem item)
        {
            _context.LineItems.Add(
                new Entity.LineItem
                {
                    Orderid = GetOrder(item.Order).Id,
                    Product = GetColor(item.Product).Id,
                    Quantity = item.Quantity
                }
            );
            _context.SaveChanges();
            return item;
        }

        public Model.Stock AddStock(Model.LineItem item, Model.Location location, int quantity)
        {
            Entity.Stock oldStock = _context.Stocks.FirstOrDefault(stock => stock.Product == GetColor(item.Product).Id && stock.Location == location.Id);
            oldStock.Quantity = oldStock.Quantity + quantity;
            _context.SaveChanges();
            //_context.ChangeTracker.Clear();
            return new Model.Stock(item.Product, location, oldStock.Quantity);
        }

        public List<Model.Order> GetLocationOrders(Model.Location location, int sort)
        {
            List<Model.Order> orders = null;
            switch (sort)
            {
                case 1:
                    orders = _context.Orders
                    .Where(ord => ord.Location == location.Id)
                    .OrderByDescending(x => x.Time)
                    .Select(
                        ord => new Model.Order(
                            ord.Id,
                            new Model.Customer(_context.Customers.FirstOrDefault(id => id.Id == ord.Customer).Name),
                            location,
                            ord.Total,
                            ord.Time)
                    ).ToList();
                    break;
                case 2:
                    orders = _context.Orders
                    .Where(ord => ord.Location == location.Id)
                    .OrderBy(x => x.Time)
                    .Select(
                        ord => new Model.Order(
                            ord.Id,
                            new Model.Customer(_context.Customers.FirstOrDefault(id => id.Id == ord.Customer).Name),
                            location,
                            ord.Total,
                            ord.Time)
                    ).ToList();
                    break;
                case 3:
                    orders = _context.Orders
                    .Where(ord => ord.Location == location.Id)
                    .OrderByDescending(x => x.Total)
                    .Select(
                        ord => new Model.Order(
                            ord.Id,
                            new Model.Customer(_context.Customers.FirstOrDefault(id => id.Id == ord.Customer).Name),
                            location,
                            ord.Total,
                            ord.Time)
                    ).ToList();
                    break;
                case 4:
                    orders = _context.Orders
                    .Where(ord => ord.Location == location.Id)
                    .OrderBy(x => x.Total)
                    .Select(
                        ord => new Model.Order(
                            ord.Id,
                            new Model.Customer(_context.Customers.FirstOrDefault(id => id.Id == ord.Customer).Name),
                            location,
                            ord.Total,
                            ord.Time)
                    ).ToList();
                    break;
                default:
                    break;
            }
            
            foreach (Order order in orders)
            {
                order.LineItems = _context.LineItems
                .Where(item => item.Orderid == order.Id)
                    .Select(
                        item => new Model.LineItem(
                            order,
                            new Model.Product(_context.Products.FirstOrDefault(id => id.Id == item.Product).Name),
                            item.Quantity
                        )
                    ).ToList();
            }

            return orders;
        }

        public List<Model.Order> GetUserOrders(Model.Customer customer, int sort)
        {
            List<Model.Order> orders = null;
            switch (sort)
            {
                case 1:
                    orders = _context.Orders
                    .Where(ord => ord.Customer == customer.Id)
                    .OrderByDescending(x => x.Time)
                    .Select(
                        ord => new Model.Order(
                            ord.Id,
                            customer,
                            new Model.Location(_context.Locations.FirstOrDefault(id => id.Id == ord.Location).City, _context.Locations.FirstOrDefault(id => id.Id == ord.Location).State),
                            ord.Total,
                            ord.Time)
                    ).ToList();
                    break;
                case 2:
                    orders = _context.Orders
                    .Where(ord => ord.Customer == customer.Id)
                    .OrderBy(x => x.Time)
                    .Select(
                        ord => new Model.Order(
                            ord.Id,
                            customer,
                            new Model.Location(_context.Locations.FirstOrDefault(id => id.Id == ord.Location).City, _context.Locations.FirstOrDefault(id => id.Id == ord.Location).State),
                            ord.Total,
                            ord.Time)
                    ).ToList();
                    break;
                case 3:
                    orders = _context.Orders
                    .Where(ord => ord.Customer == customer.Id)
                    .OrderByDescending(x => x.Total)
                    .Select(
                        ord => new Model.Order(
                            ord.Id,
                            customer,
                            new Model.Location(_context.Locations.FirstOrDefault(id => id.Id == ord.Location).City, _context.Locations.FirstOrDefault(id => id.Id == ord.Location).State),
                            ord.Total,
                            ord.Time)
                    ).ToList();
                    break;
                case 4:
                    orders = _context.Orders
                    .Where(ord => ord.Customer == customer.Id)
                    .OrderBy(x => x.Total)
                    .Select(
                        ord => new Model.Order(
                            ord.Id,
                            customer,
                            new Model.Location(_context.Locations.FirstOrDefault(id => id.Id == ord.Location).City, _context.Locations.FirstOrDefault(id => id.Id == ord.Location).State),
                            ord.Total,
                            ord.Time)
                    ).ToList();
                    break;
                default:
                    break;
            }
            
            foreach (Order order in orders)
            {
                order.LineItems = _context.LineItems
                .Where(item => item.Orderid == order.Id)
                    .Select(
                        item => new Model.LineItem(
                            order,
                            new Model.Product(_context.Products.FirstOrDefault(id => id.Id == item.Product).Name),
                            item.Quantity
                        )
                    ).ToList();
            }

            return orders;
        }

        public Model.Location CheckManager(Model.Customer user)
        {
            Entity.Location found = _context.Locations.FirstOrDefault(loc => loc.Manager == user.Id);
            if (found == null)
                return null;
            return new Model.Location(found.Id, found.City, found.State, user);
        }

        public Model.Stock AddStock(Model.Stock oldStock, Model.Location location, int quantity)
        {
            Entity.Stock updated = _context.Stocks.FirstOrDefault(stock => stock.Product == GetColor(oldStock.Product).Id && stock.Location == location.Id);
            updated.Quantity = updated.Quantity + quantity;
            _context.SaveChanges();
            //_context.ChangeTracker.Clear();
            return new Model.Stock(oldStock.Product, location, updated.Quantity);
        }

    }
}