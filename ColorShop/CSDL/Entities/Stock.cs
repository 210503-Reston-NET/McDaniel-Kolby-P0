using System;
using System.Collections.Generic;

#nullable disable

namespace CSDL.Entities
{
    public partial class Stock
    {
        public int Id { get; set; }
        public int Product { get; set; }
        public int Location { get; set; }
        public int Quantity { get; set; }

        public virtual Location LocationNavigation { get; set; }
        public virtual Product ProductNavigation { get; set; }
    }
}
