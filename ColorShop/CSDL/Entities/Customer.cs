using System;
using System.Collections.Generic;

#nullable disable

namespace CSDL.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Locations = new HashSet<Location>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
