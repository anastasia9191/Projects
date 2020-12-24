using System.Collections.Generic;
using OOP_Exercise_1.Solution.Models;

namespace OOP_Exercise_1.Solution.EmployeeService.Strategy
{
    public interface IEmployeeServiceStrategy
    {
        void Add(Employee employee);
        IEnumerable<Employee> GetAll();
    }
}
