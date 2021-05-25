using System;

namespace CSModels
{
    public class Product
    {
        private string _name;
        private double _price;
        public Product() {}
        public Product(string name)
        {
            this.Name = name;
        }
        public Product(string name, double price, string description) : this(name)
        {
            this.Price = price;
            this.Description = description;
        }
        public Product(int id, string name, double price, string description) : this(name, price, description)
        {
            this.Id = id;
        }

        public int Id { get; set; }
        public string Name { 
            get { return _name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value)) throw new Exception("Name cannot be empty!");
                _name = value;
            }
        }
        public double Price { 
            get { return _price; }
            set
            {
                _price = Math.Round(value, 2);
            }
        }
        public string Description { get; set; }

        public override string ToString()
        {
            return $" Product: {Name} \n Price: ${Price} \n Description: {Description} \n";
        }

        public bool Equals(Product product)
        {
            return this.Name.Equals(product.Name);
        }
    }
}