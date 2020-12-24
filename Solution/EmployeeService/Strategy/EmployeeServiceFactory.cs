using OOP_Exercise_1.Solution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Exercise_1.Solution.EmployeeService.Strategy
{
    public class EmployeeServiceFactory
    {
        private readonly Dictionary<EmployeeSourceType, IEmployeeService> factory;

        private EmployeeServiceFactory()
        {
            factory = new Dictionary<EmployeeSourceType, IEmployeeService>
            {
                { EmployeeSourceType.Memory, new MemoryEmployeeService() },
                { EmployeeSourceType.File, new FileEmployeeService() },
                { EmployeeSourceType.Database, new DatabaseEmployeeService() },
            };
        }
    }
}
