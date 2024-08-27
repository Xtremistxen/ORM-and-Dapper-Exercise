namespace ORM_Dapper;

public interface IProdcutRepo
{
    
    // READ ALL PRODUCT
    public IEnumerable<Product> GetAllProducts();
    
    // CREATE PRODUCT
    public void CreateProduct(string name, double price, int categoryId);
    
    // UPDATE PRODUCT
    public void UpdateProductName(int productId, string newName);
    
    //DELETE PRODUCT
    public void DeleteProduct(int productId);                                       
}