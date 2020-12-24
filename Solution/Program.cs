using System;
using System.Collections.Generic;
using OOP_Exercise_1.Solution.EmployeeService.Strategy;
using OOP_Exercise_1.Solution.Models;

namespace OOP_Exercise_1.Solution
{
    public class Program
    {
        private static IEmployeeServiceStrategy employeeService;

        static void MainRefactored(string[] args)
        {
            EmployeeSourceType sourceType;
            Enum.TryParse(args[0], out sourceType);

            EmployeeOperationType operationType;
            Enum.TryParse(args[1], out operationType);

            employeeService = new EmployeeServiceStrategy(sourceType);

            if (operationType == EmployeeOperationType.Add)
            {
                var employeToAdd = new Employee("name", "location", "job", "project");
                employeeService.Add(employeToAdd);
            }
            else if (operationType == EmployeeOperationType.Get)
            {
                IEnumerable<Employee> employees = employeeService.GetAll();
                foreach (var employee in employees)
                {
                    Console.WriteLine(employee.Name);
                }
            }
        }
    }
}
