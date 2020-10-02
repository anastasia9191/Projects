using System;
using System.IO;
using System.Linq;

namespace FileExcercice
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] line = new string[5];
            string path = @"C:\Users\asvarciuc\source\repos\FileExcercice\words.txt";
            var lines = File.ReadAllLines(path);
            
            Console.WriteLine($"Write down how many words do you whant to generate?");
            var times = Int32.Parse(Console.ReadLine());

            for(int i = 0; i< times; i++)
            {
                var r = new Random();
                var randomLineNumber = r.Next(0, lines.Length - 1);
                line[i] = lines[randomLineNumber];
               
            }
            
            for (int i=0;i< times; i++)
            {
                if (i == 0) { 
                Console.Write($"{line[i].First().ToString().ToUpper() + line[i]?.Substring(1).ToLower()} ");
                }
                else
                {
                    Console.Write($"{line[i].ToLower()} ");
                    
                }
        }
            Console.Write($".");



        }
    }
}
