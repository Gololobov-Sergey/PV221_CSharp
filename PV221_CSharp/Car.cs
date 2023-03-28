using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV221_CSharp
{
    namespace CarNC
    {
        namespace NC3
        {
            class CargoCar
            {

            }
        }
        internal class Car
        {
            public string Vendor { get; set; }

            public string Model { get; set; }

            public int Year { get; set; }

            public void Print()
            {
                Console.WriteLine($"{Vendor} {Model} {Year}");
            }
        }
    }

}
