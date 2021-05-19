namespace CSModels
{
    public class Cart
    {
        private double _amount;
        public Cart() {}
        public Cart(Customer customer, Product product, Location location, int quantity)
        {
            this.Customer = customer;
            this.Product = product;
            this.Location = location;
            this.Quantity = quantity;
        }

        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public Location Location { get; set; }
        public int Quantity { get; set; }
        public double Amount 
        { 
            get { return _amount; }
            set
            {
                _amount = Product.Price;
            }
        }
    }
}