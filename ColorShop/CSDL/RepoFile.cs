using System.Collections.Generic;
using CSModels;
using System.IO; // For the File IO
using System.Text.Json; // Json serialization (marshalling and unmarshalling)
using System;
using System.Linq;
namespace CSDL
{
    public class RepoFile : IRepository
    {
        private const string filePath1 = "../CSDL/Colors.json";
        private const string filePath2 = "../CSDL/Users.json";
        private const string filePath3 = "../CSDL/Locations.json";
        private string jsonString;

        public List<Product> GetAllColors()
        {
            try
            {
                jsonString = File.ReadAllText(filePath1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Product>();
            }
            return JsonSerializer.Deserialize<List<Product>>(jsonString);
        }

        public List<Customer> GetAllUsers()
        {
            try
            {
                jsonString = File.ReadAllText(filePath2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Customer>();
            }
            return JsonSerializer.Deserialize<List<Customer>>(jsonString);
        }
        public List<Location> GetAllLocations()
        {
            try
            {
                jsonString = File.ReadAllText(filePath3);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Location>();
            }
            return JsonSerializer.Deserialize<List<Location>>(jsonString);
        }
    }
}