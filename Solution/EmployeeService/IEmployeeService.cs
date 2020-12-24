using System.Collections.Generic;
using OOP_Exercise_1.Solution.Models;

namespace OOP_Exercise_1.Solution.EmployeeService
{
    public interface IEmployeeService
    {
        void Add(Employee employee);
        IEnumerable<Employee> GetAll();
    }
}
