using System;
using System.Collections.Generic;
using System.Linq;


namespace PerepisiNaselenia
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> personList = new List<Person>();


           
            personList.Add(new Person ( "Andrei", "Mihail", "anenii Noi"){Age = 22 });
            personList.Add(new Person ( "Svetlana","ghenadiecna", "chimislia"){Age = 22 });
            personList.Add(new Person ( "Roman","Stratiev", "dumbrava"){Age = 14 });
            personList.Add(new Person ( "Maria", "Gavriil", "chisinau") {Age = 18 });
            personList.Add(new Person ( "Petru", "Petru", "chisinau") { Age = 56 });
            personList.Add(new Person ( "Anastasia", "Gavaziuc", "dumbrava") { Age = 14 });

            var orderByResult = from s in personList
                                orderby s.Name
                                select s;

            Console.WriteLine("\nAfter sort by name:");
            foreach (Person person in orderByResult)
            {
                string z = person.PossibilityToVote() == true ? "Yes" : "No";
                Console.WriteLine($"{person.Name} {z}");

            }
            Console.WriteLine("Choose the city you whant to view");
            string city = Console.ReadLine();
            var selectResult = from s in personList
                               where s.Adress == city.ToLower()
                               select s;
            foreach (Person person in selectResult)
            {
                
                Console.WriteLine($"{person.Name} -- {person.Adress}");

            }
            Console.WriteLine("Please enter the range of age you whant to filter by");
            int value1 = Int32.Parse(Console.ReadLine());
            int value2 = Int32.Parse(Console.ReadLine());

            var filteredResult = from s in personList
                                 where s.Age > value1 && s.Age < value2
                                 select s;
            foreach (Person person in filteredResult)
            {

                Console.WriteLine($"{person.Name} -- {person.Age}");

            }




        }
    }
}
