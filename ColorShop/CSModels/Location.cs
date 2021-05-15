using System.Collections.Generic;

namespace CSModels
{
    public class Location
    {
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
        public string City { get; set; }
        public string State { get; set; }
        public Customer Manager { get; set; }
        public List<Order> OrderHistory { get; set; }
        public List<Stock> Inventory { get; set; }

        public override string ToString()
        {
            return $" Location: {City}, {State} \n    Manager: {Manager.Name} \n";
        }
    }
}