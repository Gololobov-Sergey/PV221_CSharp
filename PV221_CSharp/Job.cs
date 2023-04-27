using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV221_CSharp
{
    internal class Job
    {
        public Int64 ID { get; set; }
        public decimal  Salary { get; set; }

        public string Name { get; set; }


        public override string ToString()
        {
            return $"{ID} {Name} {Salary}";
        }
    }
}
