using System;
using System.Collections.Generic;
using System.Text;

namespace CSModels
{
    public class Order
    {
        public List<LineItem> LineItems = new List<LineItem>();
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
        

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($" Customer: {Customer.Name} \n Location: {Location.City}, {Location.State} \n \n Order: \n");
            foreach(LineItem line in LineItems)
                sb.Append(line.ToString());
            sb.Append($" \n Total amount: ${Total} \n Time: {Time} \n");
            return sb.ToString();
        }
    }
}