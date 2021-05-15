using System;
using System.Collections.Generic;

namespace CSModels
{
    public class Customer
    {
        // constructor here
        public Customer() {}
        public Customer(string name, string username, string password) 
        {
            this.Name = name;
            this.Username = username;
            this.Password = password;
        }
        public Customer(int id, string name, string username, string password) : this(name, username, password)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Order> OrderHistory { get; set; }

        public override string ToString()
        {
            return $" Name: {Name} \n    Username: {Username} \n";
        }
        public bool Equals(Customer customer)
        {
            return this.Username.Equals(customer.Username) || this.Name.Equals(customer.Name);
        }

    }
}
