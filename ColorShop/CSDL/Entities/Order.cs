using System;
using System.Collections.Generic;

#nullable disable

namespace CSDL.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public int Customer { get; set; }
        public int Location { get; set; }
        public double Total { get; set; }
        public DateTime Time { get; set; }

        public virtual Customer CustomerNavigation { get; set; }
        public virtual Location LocationNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
