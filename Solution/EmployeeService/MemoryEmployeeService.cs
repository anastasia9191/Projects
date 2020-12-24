using System.Collections.Generic;
using System.Linq;
using OOP_Exercise_1.Solution.Models;

namespace OOP_Exercise_1.Solution.EmployeeService
{
    public class MemoryEmployeeService : IEmployeeService
    {
        private List<Employee> MemoryCache { get; } = new List<Employee>();

        public void Add(Employee employee)
        {
            MemoryCache.Add(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return MemoryCache.AsEnumerable();
        }
    };
}
