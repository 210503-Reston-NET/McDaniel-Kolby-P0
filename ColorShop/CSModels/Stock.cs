namespace CSModels
{
    public class Stock
    {
        public Stock() {}
        public Stock(Product product, Location location, int quantity)
        {
            this.Product = product;
            this.Location = location;
            this.Quantity = quantity;
        }
        public Stock(int id, Product product, Location location, int quantity) : this(product, location, quantity)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public Product Product { get; set; }
        public Location Location { get; set; }
        public int Quantity { get; set; }
        public override string ToString()
        {
            return $"Location: {Location.City}, {Location.State} \n Product: {Product.Name} \n Price: {Product.Price} \n Stock: {Quantity} \n";
        }
    }
}