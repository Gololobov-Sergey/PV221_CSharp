using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV221_CSharp
{
    partial class Student
    {
        int id;
        string firstName;
        string lastName;
        DateTime birthDay;

        public const int group = 1;

        public readonly int group_id = 1;

        public readonly int[] arr = { 3, 4, 5 };

        static string planet;


        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value == "Oleg")
                    name = "Petro";
                else
                    name = value;
            }
        }



        public int MyProperty { get; set; }



        public Student() : this("No Name", "No LastName")
        {
            
        }

        public Student(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }


        static Student()
        {
            planet = "Earth";
        }

        public void Print()
        {
            Console.WriteLine($"{lastName} {firstName}, BD : {birthDay.ToShortDateString()}");
        }

        public void PPPPPP()
        {

        }



        public static string GetPlanet() 
        { 
            return planet; 
        }

        public static void SetPlanet(string planet) 
        {
            Student.planet = planet; 
        }

    }
}
