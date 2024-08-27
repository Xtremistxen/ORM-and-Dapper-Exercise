using System.Data;
using Dapper;

namespace ORM_Dapper;

public class DapperProductRepo : IProdcutRepo
{
    
    private readonly IDbConnection _conn;

    public DapperProductRepo(IDbConnection conn)
    {
        _conn = conn;
    }
    
    public IEnumerable<Product> GetAllProducts()
    {
        return _conn.Query<Product>("SELECT * FROM products;");
    }
    
    public void CreateProduct(string name, double price, int categoryId)
    {
        _conn.Execute("INSERT INTO products (Name, Price, CategoryID) VALUES (@name, @price, @categoryId);", new {name, price, categoryId});
    }

    public void UpdateProductName(int productId, string newName)
    {
        _conn.Execute("UPDATE products SET Name = @newName, WHERE ProductID = @productId;", new {productId, newName});
    }

    public void DeleteProduct(int productId)
    {
        _conn.Execute("DELETE FROM reviews WHERE productID = @productId;", new {productId});
        _conn.Execute("DELETE FROM sales WHERE productID = @productId;", new {productId});
        _conn.Execute("DELETE FROM products WHERE productID = @productId;", new {productId});
    }
    
}