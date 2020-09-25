using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerepisiNaselenia
{
    class Person : IComparable
    {
        public string Name { get; set; }
        public string Fname { get; set; }
        public string Adress { get; set; }
        
        private int age;
        public int Age
        {
            set
            {
                if (value < 19)
                {
                    Console.WriteLine("The age should be more than 19");
                }
                else
                {
                    age = value;
                }
            }
            get { return age; }
        }
        public int CompareTo(object o)
        {
            Person p = o as Person;
            if (p != null)
                return this.Name.CompareTo(p.Name);
            else
                throw new Exception("Impossible to compare 2 objects");
        }
    }
}

