namespace ORM_Dapper;

public interface IProdcutRepository
{
    // CREATE PRODUCT
    public void CreateProduct(string name, double price, int categoryID);
    
    // READ ALL PRODUCT
    public IEnumerable<Product> GetAllProducts();
    
    //READ SINGLE PRODUCT
    public Product GetSingleProduct(int productID);
    
    // UPDATE PRODUCT
    public void UpdateProduct(int id, Product p);
    
    //DELETE PRODUCT
    public void DeleteProduct(int id);                                       
}