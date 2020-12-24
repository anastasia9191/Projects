using System;
using System.Collections;

namespace AppVerify
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "great day";
            // индекс последнего символа
            int ind = text.Length - 1;
            // вырезаем последний символ
            text = text.Remove(ind);
            Console.WriteLine(text);

            // вырезаем первые два символа
            text = text.Remove(0, 2);
        }
      
    }
    }

