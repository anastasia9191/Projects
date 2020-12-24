namespace OOP_Exercise_1.Solution.Models
{
    public class Employee
    {
        public Employee(string name, string location, string job, string project)
        {
            Name = name;
            Job = job;
            Location = location;
            Project = project;
        }

        public string Name { get; }
        public string Location { get; }
        public string Job { get; }
        public string Project { get; }
    }
}
