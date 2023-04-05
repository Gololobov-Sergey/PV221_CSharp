using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV221_CSharp
{
    internal class MyArray
    {
        int[] arr;

        public int Length { get;  }

        public MyArray(int size)
        {
            Length = size;
            arr = new int[size];
        }

        public void SetRandom(int min, int max)
        {
            for (int i = 0; i < Length; i++)
            {
                arr[i] = new Random().Next(min, max);
            }
        }

        public override string ToString()
        {
            StringBuilder st = new StringBuilder();
            return st.AppendJoin(", ", arr).ToString();
        }
    }
}
