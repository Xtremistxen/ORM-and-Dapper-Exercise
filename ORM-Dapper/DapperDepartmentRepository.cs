using System.Data;
using Dapper;

namespace ORM_Dapper;

public class DapperDepartmentRepository : IDepartmentRepository
{
    private readonly IDbConnection _connection;

    public DapperDepartmentRepository(IDbConnection conn)
    {
        _connection = conn;
    }

    public void CreateDepartment(string name)
    {
        _connection.Execute("INSERT INTO departments (Name) VALUES (@name);",
            new { name });
    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _connection.Query<Department>("SELECT * FROM departments;");
    }

    public void DeleteDepartment(int id)
    {
        _connection.Execute("DELETE FROM departments WHERE DepartmentID = @id;", new { id });
        _connection.Execute("DELETE FROM categories WHERE DepartmentID = @id;", new { id });
    }

    public Department GetSingleDepartment(int id)
    {
        return _connection.QuerySingle<Department>("SELECT * FROM departments WHERE DepartmentID = @id;", new { id });
    }

    public void UpdateDepartment(int id, string name)
    {
        _connection.Execute("UPDATE departments SET name = @name WHERE DepartmentID = @id;", new { name, id });
    }
    
}
