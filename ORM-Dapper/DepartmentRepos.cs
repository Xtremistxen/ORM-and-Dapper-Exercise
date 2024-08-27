using System.Data;
using Dapper;

namespace ORM_Dapper;

public class DepartmentRepos : IDepartmentRepo
{
    private readonly IDbConnection _connection;

    public DepartmentRepos(IDbConnection conn)
    {
        _connection = conn;
    }
    
    public IEnumerable<Department> GetAllDepartments()
    {
        return _connection.Query<Department>("SELECT * FROM departments");
    }
    
    public void InsertDepartment(string newDepartmentName)
    {
        _connection.Execute("INSERT INTO departments (Name) VALUES (@newDepartmentName)", new { newDepartmentName });
    }
    
}