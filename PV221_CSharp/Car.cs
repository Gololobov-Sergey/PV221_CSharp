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

            public void Print() => Console.WriteLine($"{Vendor} {Model} {Year}");

        }
    }



    [Serializable]
    public class MyException : Exception
    {
        public MyException() 
        {
            Data.Add("data", DateTime.Now);
        }
        public MyException(string message) : base(message) { }
        public MyException(string message, Exception inner) : base(message, inner) { }
        protected MyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

}
