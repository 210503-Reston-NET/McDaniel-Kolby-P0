namespace CSModels
{
    public class LineItem
    {
        public LineItem() {}
        public LineItem(Order order, Product product, int quantity)
        {
            this.Order = order;
            this.Product = product;
            this.Quantity = quantity;
        }
        public LineItem(int id, Order order, Product product, int quantity) : this(order, product, quantity)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public override string ToString()
        {
            return $"   LineItem: {Quantity} x {Product.Name} \n   Price: ${Quantity * Product.Price} \n";
        }


    }
}