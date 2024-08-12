using System.Data;
using Dapper;

namespace ORM_Dapper;

public class DapperProductRepository : IProdcutRepository
{
    
    private readonly IDbConnection _conn;

    public DapperProductRepository(IDbConnection conn)
    {
        _conn = conn;
    }

    public void CreateProduct(string name, double price, int categoryID, string stock)
    {
        _conn.Execute("INSERT INTO products (name, price, categoryID, stocklevel) VALUES (@name, @price, @categoryID, @stocklevel);", new { name, price, categoryID, stocklevel = stock });
    }

    public void DeleteProduct(int id)
    {
        _conn.Execute("DELETE FROM products WHERE productID = @id;", new { id });
        _conn.Execute("DELETE FROM sales WHERE productID = @id;", new { id });
        _conn.Execute("DELETE FROM reviews WHERE productID = @id;", new { id });
    }

    public void CreateProduct(string name, double price, int categoryID)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _conn.Query<Product>("SELECT * FROM products;");
    }

    public Product GetSingleProduct(int productID)
    {
        return _conn.QuerySingle<Product>("SELECT * FROM products WHERE productID = @productID", new { productID });
    }

    public void UpdateProduct(int id, Product p)
    {
        _conn.Execute("UPDATE products SET name = @name, price = @price, categoryID = @category, stocklevel = @stock WHERE productID = @id;", new { id, name = p.Name, price = p.Price, category = p.CategoryID, stock = p.StockLevel });
    }
}