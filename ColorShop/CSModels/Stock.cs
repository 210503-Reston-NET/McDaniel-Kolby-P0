namespace CSModels
{
    public class Stock
    {
        public Stock() {}
        public Stock(Product product, Location location, int quantity, int max)
        {
            this.Product = product;
            this.Location = location;
            this.Quantity = quantity;
            this.Max = max;
        }
        public Stock(int id, Product product, Location location, int quantity, int max) : this(product, location, quantity, max)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public Product Product { get; set; }
        public Location Location { get; set; }
        public int Quantity { get; set; }
        public int Max { get; set; }
        public override string ToString()
        {
            return $"Location: {Location} \n Color: {Product} \n Stock: {Quantity} \n";
        }
    }
}