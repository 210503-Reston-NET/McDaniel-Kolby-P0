using System;
using Xunit;
using CSModels;


namespace CSTests
{
    public class ProductTest
    {
        [Fact]
        public void ProductShouldSetValidData()
        {
            // Arrange 
            string color = "Orange";
            Product test = new Product();

            //Act
            test.Name = color;

            //Assert 
            Assert.Equal(color, test.Name);
        }
        [Fact]
        public void PriceShouldSetCorrectvalue()
        {
            //Arrange 
            Product test = new Product();
            test.Price = 10;

            //Act & Assert
            Assert.Equal(10.00, test.Price);
        }
        [Theory]
        [InlineData("")]
        public void ProductNameShouldNotSetInvalidData(string input)
        {
            //Arrange 
            Product test = new Product();

            //Act & Assert
            Assert.Throws<Exception>(() => test.Name = input);
        }
    }
}