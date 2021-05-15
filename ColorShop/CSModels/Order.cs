using System;
using System.Collections.Generic;

namespace CSModels
{
    public class Order
    {
        public Order() {}
        public Order(Customer customer, Location location, double total, DateTime time)
        {
            this.Customer = customer;
            this.Location = location;
            this.Total = total;
            this.Time = time;
        }
        public Order(int id, Customer customer, Location location, double total, DateTime time) : this(customer, location, total, time)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public double Total { get; set; }
        public DateTime Time { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }

        public override string ToString()
        {
            return $" Customer: {Customer} \n Location: {Location} \n Total amount: ${Total} \n Items: {OrderDetails.ToString()} \n Time: {Time} \n";
        }
    }
}