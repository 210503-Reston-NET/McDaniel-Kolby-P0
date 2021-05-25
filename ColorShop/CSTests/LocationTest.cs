using System;
using Xunit;
using CSModels;

namespace CSTests
{
    public class LocationTest
    {
        [Fact]
        public void LocationShouldSetValidData()
        {
            // Arrange 
            string city = "Tallahassee";
            Location test = new Location();

            //Act
            test.City = city;

            //Assert 
            Assert.Equal(city, test.City);
        }
        [Theory]
        [InlineData("2345678i")]
        [InlineData("beufkjsdhfkjs1")]
        public void LocationShouldNotSetInvalidData(string input)
        {
            //Arrange 
            Location test = new Location();

            //Act & Assert
            Assert.Throws<Exception>(() => test.City = input);
        }
    }
}