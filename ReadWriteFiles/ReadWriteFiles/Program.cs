using System;
using System.Text;
using System.IO;

namespace ReadWriteFiles
{
    class Program
    {
     
  
    static void Main(string[] args)
        {
            StreamReader sr; 
            StreamWriter sw; 
            const int NmaxZap = 10; 
            try
            {
                
                sr = new StreamReader(@"C:\Users\asvarciuc\source\repos\ReadWriteFiles\ReadWriteFiles\bin\Debug\netcoreapp3.1\info.txt", UTF8Encoding.Default);
                string[] d = new string[NmaxZap];
                string t = sr.ReadLine(); 
                int i = 0; 
                while ((t != null) && (i < d.Length)) 
                {
                    Console.WriteLine(t); 
                    d[i++] = t; 
                    t = sr.ReadLine(); 
                }
                sr.Close(); 

                d[i] = "седьмая строка"; 

                 
                FileInfo fi = new FileInfo(@"C:\Users\asvarciuc\source\repos\ReadWriteFiles\ReadWriteFiles\bin\Debug\netcoreapp3.1\result.txt"); // информация о файле 
                if (fi.Exists)
                    sw = fi.AppendText(); 
                else
                    sw = fi.CreateText(); 
                for (int j = 0; j <= i; j++)
                    sw.WriteLine(d[j].ToString()); 
                sw.Close();
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Нет файла для чтения!" + ex);
            }
            Console.ReadKey();
        }
    }


}
    

