using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;

namespace MyToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\asvarciuc\source\repos\MyToDoList\MyToDoList\bin\Debug\netcoreapp3.1\task.json";
            Console.WriteLine($"How many tasks do you have?");
            var numberOfTasks = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Enter the tasks you need to accomplish");
            List<string> tasks = new List<string>();
            using (FileStream fs = new FileStream("task.json", FileMode.OpenOrCreate))
            {
                for (int i = 0; i < numberOfTasks; i++)
                {
                    tasks.Add(Console.ReadLine());
                }
                if (File.Exists(path))
                    File.Delete(path);
                var textFile = JsonSerializer.Serialize(tasks.ToArray());
                System.IO.File.WriteAllText(path, textFile);
                Console.WriteLine($"{textFile}");
            }
            
            var actions = new ActionsNotes();
            //actions.ShowNotes(tasks);
         
        }
    }
}
