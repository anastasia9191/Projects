using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PerepisiNaselenia
{
    class Person 
    {
        public Person(string name, string fname, string adress ) 
        {
            Name = name;
            Fname = fname;
            Adress = adress;
            Email = $"{name}.{fname}@gmail.com";
        }
        public Person(string name)
        {
            Name = name;
        }



        public string Name { get; }
        public string Fname { get; }
        public string Adress { get;  }
        public string Email { get;  }

        

        private int age;
        public int Age
        {
            set
            {
                if (value < 18)
                {
                     Console.WriteLine("The age should be more than 18");
                }
                else
                {
                    age = value;
                }
            }
            get { return age; }
        }
        

        public bool PossibilityToVote() 
        {
            if (Age >= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
         }
    }
}

