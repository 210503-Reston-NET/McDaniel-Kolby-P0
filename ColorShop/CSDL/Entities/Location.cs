using System;
using System.Collections.Generic;

#nullable disable

namespace CSDL.Entities
{
    public partial class Location
    {
        public Location()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
            Stocks = new HashSet<Stock>();
        }

        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Manager { get; set; }

        public virtual Customer ManagerNavigation { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
