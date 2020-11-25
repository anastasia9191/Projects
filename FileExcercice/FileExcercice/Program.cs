using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace FileExcercice
{
    class Program
    {
        static void Main(string[] args)
        {            
            string path = @"C:\Users\asvarciuc\source\repos\FileExcercice\words.txt";
            var lines = File.ReadAllLines(path);
            
            Console.WriteLine($"Write down how many words do you whant to generate?");
            var times = Int32.Parse(Console.ReadLine());
            string result = "";

            var timer = Stopwatch.StartNew();

            //var sb = new StringBuilder();
            for (int i = 0; i < times; i++)
            {
                var r = new Random();
                var randomLineNumber = r.Next(0, lines.Length - 1);
                //sb.Append(lines[randomLineNumber]);
                result += lines[randomLineNumber];

                if (i < (times - 1))
                {
                    result += " ";
                    //sb.Append(" ");
                }
            }
            result += ".";
            //sb.Append(".");
            //Console.Write($"{result} ");

            timer.Stop();

            Console.Write($"{timer.ElapsedMilliseconds} ");

            string[] substring = new string[times];

            //for (int i = 0; i < times; i++)
            //{
            //    if (i == 0)
            //    {
            //        substring[i] += ($"{line[i].First().ToString().ToUpper() + line[i]?.Substring(1).ToLower()} ");
            //    }
            //    else
            //    {
            //        substring[i] += ($"{line[i].ToLower()} ");

            //    }
            //}
            

            var preposition = string.Join(" ", substring);
            //Console.Write($"{preposition}.");
        


        }
    }
}
