namespace CSModels
{
    public class Cart
    {
        public Cart() {}
        public Cart(Product product, int quantity, double amount)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.Amount = amount;
        }

        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
    }
}