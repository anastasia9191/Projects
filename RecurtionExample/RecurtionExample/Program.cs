using System;

namespace RecurtionExample
{
    class Program
    {
        //public static int CalculateSumRecursively(int n, int m)
        //{
        //    int sum = n;
        //    if (n < m)
        //    {
        //        n++;
        //        return sum += CalculateSumRecursively(n, m);
        //    }
        //    return sum;
        //}
        static void Main(string[] args)
        {
            //Console.WriteLine("Enter number n: ");
            //int n = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter number m: ");
            //int m = Convert.ToInt32(Console.ReadLine());
            //int sum = CalculateSumRecursively(n, m);
            //Console.WriteLine(sum);
            //Console.ReadKey();


            int value = 5;
            int ret;
            Factorial fact = new Factorial();
            ret = fact.display(value);
            Console.WriteLine("Value is : {0}", ret);
            Console.ReadLine();

            //var result = new Function();
            //result.PritnNumbers(10, 10);
            //Console.ReadKey();

            //Console.Write("\n\n Recursion : Sum of first n natural numbers :\n");
            //Console.Write("--------------------------------------------------\n");
            //Console.Write(" How many numbers to sum : ");
            //int n = Convert.ToInt32(Console.ReadLine());
            //Console.Write(" The sum of first {0} natural numbers is : {1}\n\n", n, SumOfTen(1, n));
        }
        class Factorial
        {
            public int display(int n)
            {
                if (n == 1)
                    return 1;
                else
                    return n * display(n - 1);
            }
        }

        //public static int CalcuSum(int n, int m)
        //{

        //    if (m == n)
        //    {
        //        return n;
        //    }
        //    else
        //    {


        //        return m += CalcuSum(n, m-1);   
        //    }

        //}

        //static int SumOfTen(int min, int max)
        //{
        //    return CalcuSum(min, max);
        //}
    }
}