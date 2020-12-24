using System;
using System.Linq;
namespace Verify
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[4] {4,-8, 0, 1 };
            var result1 = myArray.Select(c => Math.Abs(c)).Where(c => c > 0).OrderBy(c => c);
           // var result = result1.Where(c => c > 0).OrderBy(c=>c);
            foreach(var value in result1)
            {
                Console.WriteLine(value);
            }
            

        }
    }
}
