using System;

namespace CSModels
{
    public class Product
    {
        public Product() {}
        public Product(string name, double price, string description)
        {
            this.Name = name;
            this.Price = price;
            this.Description = description;
        }
        public Product(int id, string name, double price, string description) : this(name, price, description)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price 
        {
            get { return this.Price; }
            set
            {
                if (this.Price <= 0)
                {
                    throw new Exception("Price should be greater than zero.");
                }
                this.Price = value;
            } 
        }
        public string Description { get; set; }

        public override string ToString()
        {
            return $" Product: {Name} \n Price: ${Price} \n Description: {Description}";
        }

        public bool Equals(Product product)
        {
            return this.Name.Equals(product.Name);
        }
    }
}