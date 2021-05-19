using System;
using System.Collections.Generic;

#nullable disable

namespace CSDL.Entities
{
    public partial class Product
    {
        public Product()
        {
            LineItems = new HashSet<LineItem>();
            Stocks = new HashSet<Stock>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
