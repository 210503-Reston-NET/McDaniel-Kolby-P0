namespace CSModels
{
    public class OrderDetails
    {
        public OrderDetails() {}
        public OrderDetails(Order order, Product product, int quantity, double amount)
        {
            this.Order = order;
            this.Product = product;
            this.Quantity = quantity;
            this.Amount = amount;
        }
        public OrderDetails(int id, Order order, Product product, int quantity, double amount) : this(order, product, quantity, amount)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }


    }
}