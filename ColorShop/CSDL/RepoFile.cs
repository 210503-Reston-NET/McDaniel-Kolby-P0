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
        private const string filePath = "../CSDL/Colors.json";
        private string jsonString;

        public List<Product> GetAllColors()
        {
            try
            {
                jsonString = File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Product>();
            }
            return JsonSerializer.Deserialize<List<Product>>(jsonString);
        }
    }
}