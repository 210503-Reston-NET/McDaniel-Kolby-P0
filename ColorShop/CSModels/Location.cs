using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSModels
{
    public class Location
    {
        private string _city;
        public Location() {}
        public Location(string city, string state)
        {
            this.City = city;
            this.State = state;
        }
        public Location(string city, string state, Customer manager) : this(city, state)
        {
            this.Manager = manager;
        }
        public Location(int id, string city, string state, Customer manager) : this(city, state, manager)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public string City { 
            get { return _city; }
            set
            {
                if (!Regex.IsMatch(value, @"^[A-Za-z .]+$")) throw new Exception("City cannot have numbers!");
                _city = value;
            }
        }
        public string State { get; set; }
        public Customer Manager { get; set; }
        public List<Order> OrderHistory { get; set; }
        public List<Stock> Inventory { get; set; }

        public override string ToString()
        {
            return $" Location: {City}, {State} \n Manager: {Manager.Name} \n";
        }
    }
}