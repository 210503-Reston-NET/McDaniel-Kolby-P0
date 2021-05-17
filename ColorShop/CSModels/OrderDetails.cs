namespace CSModels
{
    public class OrderDetails
    {
        public OrderDetails() {}
        public OrderDetails(Order order, Product product, int quantity)
        {
            this.Order = order;
            this.Product = product;
            this.Quantity = quantity;
        }
        public OrderDetails(int id, Order order, Product product, int quantity) : this(order, product, quantity)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }


    }
}