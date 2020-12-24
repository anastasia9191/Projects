using System.Collections.Generic;
using OOP_Exercise_1.Solution.Models;

namespace OOP_Exercise_1.Solution.EmployeeService.Strategy
{
    public class EmployeeServiceStrategy : IEmployeeServiceStrategy
    {
        private readonly IEmployeeService employeeService;

        public EmployeeServiceStrategy(EmployeeSourceType employeeSourceType)
        {
            var dependencyConfig = new Dictionary<EmployeeSourceType, IEmployeeService>
            {
                { EmployeeSourceType.Memory, new MemoryEmployeeService() },
                { EmployeeSourceType.File, new FileEmployeeService() },
                { EmployeeSourceType.Database, new DatabaseEmployeeService() },
            };

            employeeService = dependencyConfig[employeeSourceType];
        }

        public void Add(Employee employee)
        {
            employeeService.Add(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return employeeService.GetAll();
        }
    }
}
