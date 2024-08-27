namespace ORM_Dapper;

public interface IDepartmentRepo
{
    // CREATE a Department
    public void InsertDepartment(string name);          
    
    // Read a Department
    public IEnumerable<Department> GetAllDepartments();
    
}