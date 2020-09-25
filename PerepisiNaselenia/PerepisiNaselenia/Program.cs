using System;
using System.Collections.Generic;

namespace PerepisiNaselenia
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> person = new List<Person>();

            Person p1 = new Person { Name = "Maria", Fname = "Gavriil", Adress ="Chisinau", Age = 18};
            Person p2 = new Person  { Name = "Andrei", Fname = "Mihail", Adress = "Anenii Noi", Age = 22 };
            Person p3 = new Person { Name = "Svetlana", Fname = "ghenadiecna", Adress = "Chimislia", Age = 22 };

            Person[] people = new Person[] { p1, p2, p3 };
            Array.Sort(people);

            foreach (Person p in people)
            {
                Console.WriteLine($"{p.Name} - {p.Fname} - {p.Adress} - {p.Age}");
            }

            

        }
    }
}
