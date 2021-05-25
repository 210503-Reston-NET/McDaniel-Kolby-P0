using System.Reflection;
using System;
using Xunit;
using CSModels;

namespace CSTests
{
    public class UserTest
    {
        [Fact]
        public void UserShouldSetValidData()
        {
            // Arrange 
            string name = "Test";
            Customer test = new Customer();

            //Act
            test.Name = name;

            //Assert 
            Assert.Equal(name, test.Name);
        }
        [Theory]
        [InlineData("")]
        public void NameShouldNotSetInvalidData(string input)
        {
            //Arrange 
            Customer test = new Customer();

            //Act & Assert
            Assert.Throws<Exception>(() => test.Name = input);
        }

        [Theory]
        [InlineData("")]
        public void UsernameShouldNotSetInvalidData(string input)
        {
            //Arrange 
            Customer test = new Customer();

            //Act & Assert
            Assert.Throws<Exception>(() => test.Username = input);
        }

        [Theory]
        [InlineData("")]
        public void PasswordShouldNotSetInvalidData(string input)
        {
            //Arrange 
            Customer test = new Customer();

            //Act & Assert
            Assert.Throws<Exception>(() => test.Password = input);
        }
    }
}