using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using OOP_Exercise_1.Solution.Models;

namespace OOP_Exercise_1.Solution.EmployeeService
{
    public class DatabaseEmployeeService : IEmployeeService
    {
        private const string DbConnString = "connString";

        public void Add(Employee employee)
        {
            using (var conn = GetDbConnection())
            {
                conn.Execute(@"INSERT INTO SomeTable (Name, Location, Job, Project) Values (@Name, Location, Job, Project)",
                new
                {
                    Name = employee.Name,
                    Location = employee.Location,
                    Job = employee.Job,
                    Project = employee.Project
                });
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            IEnumerable<Employee> employees;
            using (var conn = GetDbConnection())
            {
                employees = conn.Query<Employee>("SELECT * FROM SomeTable").AsEnumerable();
            }

            return employees;
        }

        private SqlConnection GetDbConnection()
        {
            return new SqlConnection(DbConnString);
        }
    }
}
