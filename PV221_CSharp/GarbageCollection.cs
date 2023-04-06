using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV221_CSharp
{
    internal class GarbageGenerator : IDisposable
    {
        public GarbageGenerator() 
        {
            Console.WriteLine("Connect DB");
        }   
        public void CreateGarbage()
        {
            Student[] s = new Student[10000000];
            for (int i = 0; i < 10000000; i++)
            {
                s[i] = new Student();
            }
        }

        public void Dispose()
        {
            Console.WriteLine("Close connect DB");
        }
    }
}
