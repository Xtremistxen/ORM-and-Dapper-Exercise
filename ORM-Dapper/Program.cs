using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace ORM_Dapper
{
    public static class Program
    {
        public static void Main(string[]args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connString = config.GetConnectionString("DefaultConnection");

            using IDbConnection conn = new MySqlConnection(connString);
            // create connection to db
            var productRepo = new DapperProductRepository(conn);

            // Creating new product
            productRepo.CreateProduct("Mysterious Serum", 0.99, 10, "1");

            // Storing all products as an IEnumerable
            var products = productRepo.GetAllProducts();
            products.ToList().ForEach(x => Console.WriteLine(x.Name + ": " + x.Price));

            // Selecting a single product
            var product = productRepo.GetSingleProduct(941);
            Console.WriteLine(product.Name + " " + product.Price);

            // Updating a product
            var prod = new Product
            {
                Name = "Rad Roach Meat",
                Price = 999,
                CategoryID = 10,
                StockLevel = 25
            };

            productRepo.UpdateProduct(942, prod);

            // This will delete a product from the database
            productRepo.DeleteProduct(941);

            // Run department operations
            RunDepartment(conn);
        }

        private static void RunDepartment(IDbConnection conn)
        {
            // create connection to db
            var departmentRepo = new DapperDepartmentRepository(conn);

            // create new department
            //departmentRepo.CreateDepartment("XR");

            // This will store all departments as an IEnumerable
            var departments = departmentRepo.GetAllDepartments();

            // This will display all departments
            departments.ToList().ForEach(x => Console.WriteLine($"\n{x.DepartmentID}: {x.Name}"));

            // This will update created department
            departmentRepo.UpdateDepartment(6, "AR");

            // This will display all departments
            departments = departmentRepo.GetAllDepartments();
            departments.ToList().ForEach(x => Console.WriteLine($"\n{x.DepartmentID}: {x.Name}"));

            // This will Delete from department
            departmentRepo.DeleteDepartment(7);

            // This will display all departments
            departments = departmentRepo.GetAllDepartments();
            departments.ToList().ForEach(x => Console.WriteLine($"\n{x.DepartmentID}: {x.Name}"));
        }
    }
}



            
        
 

       