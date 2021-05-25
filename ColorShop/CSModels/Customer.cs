using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSModels
{
    public class Customer
    {
        // constructor here
        private string _name;
        private string _username;
        private string _password;
        public Customer() {}
        public Customer(string name)
        {
            this.Name = name;
        }
        public Customer(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public Customer(string name, string username, string password) : this(username, password)
        {
            this.Name = name;
        }
        public Customer(int id, string name, string username, string password) : this(name, username, password)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public string Name { 
            get { return _name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new Exception("Name cannot be empty!");
                _name = value;
            }
        }
        public string Username {
            get { return _username; }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new Exception("Username cannot be empty!");
                _username = value;
            }
        }
        public string Password {
            get { return _password; }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new Exception("Password cannot be empty!");
                _password = value;
            }
        }
        public List<Order> OrderHistory { get; set; }

        public override string ToString()
        {
            return $" Name: {Name} \n Username: {Username} \n";
        }
        public bool Equals(Customer customer)
        {
            return this.Username.Equals(customer.Username) || this.Name.Equals(customer.Name);
        }

    }
}
