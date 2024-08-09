namespace ORM_Dapper;

public interface IDepartmentRepository
{
    // CREATE a Department
    public void CreateDepartment(string name);          
    
    // Read a Department
    public IEnumerable<Department> GetAllDepartments();
    
    //Read a Single Department
    public Department GetSingleDepartment(int id);
    
    // Update a Department
    public void UpdateDepartment(int id, string name);
    
    // Delete a Department
    public void DeleteDepartment(int id);               
}