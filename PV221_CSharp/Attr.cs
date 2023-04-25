using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV221_CSharp
{


    [AttributeUsage(AttributeTargets.All, /*Inherited = false,*/ AllowMultiple = true)]
    class ProgrammerAttribute : Attribute
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
 

        public ProgrammerAttribute(string name, string date)
        {
            Name = name;   
            Date = Convert.ToDateTime(date);
        }

        public override string ToString()
        {
            return $"Author: {Name}, Date: {Date.ToShortDateString()}";
        }
    }


    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    class AgeValidationAttribute : Attribute
    {
        public int Age { get; set; }      
        public AgeValidationAttribute(int age) {  Age = age; }

    }
}
