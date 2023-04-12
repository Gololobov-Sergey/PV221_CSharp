using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PV221_CSharp
{
    public abstract class Human
    {
        protected string FirstName;
        protected string LastName;
        protected int id;

        public Human() { }

        public Human(string fName, string lName) 
        {
            FirstName = fName;
            LastName = lName;
        }

        public abstract void Dancing();

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }

    /*sealed*/
    public abstract class Employee : Human
    {
        new int iddddd;
        int Salary;

        public Employee()
        {
            
        }

        public Employee(string fName, string lName, int salary) : base(fName, lName)
        {
            this.Salary = salary;
        }

        public /*sealed*/ override string ToString()
        {
            return base.ToString() + $", Salary {Salary}";
        }
    }

    
    class Director : Employee
    {
        int numberSubordinates;

        public Director(string fName, string lName, int salary, int numSubo) :
            base(fName, lName, salary)
        {
            numberSubordinates = numSubo;
        }

        public override void Dancing()
        {
            Console.WriteLine("I`m dancing Gopak");
        }

        public void PrintSubordinate()
        {
            Console.WriteLine($"Subordinate  : {numberSubordinates}");
        }

        public override string ToString()
        {
            return base.ToString() + $", Subordinate  : {numberSubordinates}";
        }
    }

    class Economist : Employee
    {
        int experience;

        public Economist(string fName, string lName, int salary, int experience) :
            base(fName, lName, salary)
        {
            this.experience = experience;
        }

        public override void Dancing()
        {
            Console.WriteLine("I`m dancing Val`s");
        }

        public void PrintExperience()
        {
            Console.WriteLine($"Experience  : {experience}");
        }

        public override string ToString()
        {
            return base.ToString() + $", Experience  : {experience}";
        }
    }


    class CleaningManager : Employee
    {
        int cleaningArea;

        public CleaningManager(string fName, string lName, int salary, int cleaningArea) :
            base(fName, lName, salary)
        {
            this.cleaningArea = cleaningArea;
        }

        public override void Dancing()
        {
            Console.WriteLine("I`m dancing Pol`ka");
        }

        public void PrintCleaningArea()
        {
            Console.WriteLine($"Cleaning Area  : {cleaningArea}");
        }

        public override string ToString()
        {
            return base.ToString() + $", Cleaning Area {cleaningArea}";
        }

    }

    internal class Buhgalter : Employee
    {
        private int count;

        public bool Zvit
        {
            get => default;
            set
            {
            }
        }

        public override void Dancing()
        {
            throw new NotImplementedException();
        }

        public void GetZvit()
        {
            throw new System.NotImplementedException();
        }
    }
}
