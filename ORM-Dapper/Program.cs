using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace ORM_Dapper
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connString = config.GetConnectionString("DefaultConnection");
            using IDbConnection conn = new MySqlConnection(connString);
            // create connection to db

            var prodRepo = new DapperProductRepo(conn);
            
            prodRepo.CreateProduct("Boogerman", 49.99, 8);
            prodRepo.UpdateProductName(941, "Escape From House of Dead");
            prodRepo.DeleteProduct(941);

            var products = prodRepo.GetAllProducts();

            foreach (var product in products)
            {
                Console.WriteLine(
                    $"ID: {product.ProductID} Name: {product.Name} Price: {product.Price} Category ID: {product.CategoryID} On Sale {product.OnSale} Stock Level: {product.StockLevel}");
            }
        }
    }
}



            
        
 

       