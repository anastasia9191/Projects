using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using OOP_Exercise_1.Solution.Models;

namespace OOP_Exercise_1.Solution.EmployeeService
{
    class FileEmployeeService : IEmployeeService
    {
        private const string FileToRead = @"test.json";

        public void Add(Employee employee)
        {
            List<Employee> employees = GetEmployeesFromFile();
            employees.Add(employee);
            System.IO.File.WriteAllText(FileToRead, JsonConvert.SerializeObject(employees));
        }

        public IEnumerable<Employee> GetAll()
        {
            return GetEmployeesFromFile().AsEnumerable();
        }

        private List<Employee> GetEmployeesFromFile()
        {
            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(System.IO.File.ReadAllText(FileToRead));
            return employees;
        }
    }
}
