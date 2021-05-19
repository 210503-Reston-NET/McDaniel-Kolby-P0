using System;
using System.Collections.Generic;

#nullable disable

namespace CSDL.Entities
{
    public partial class LineItem
    {
        public int Id { get; set; }
        public int Orderid { get; set; }
        public int Product { get; set; }
        public int Quantity { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product ProductNavigation { get; set; }
    }
}
