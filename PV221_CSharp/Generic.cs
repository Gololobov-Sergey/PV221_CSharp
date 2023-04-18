using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV221_CSharp
{

    public class Point2D<T> where T: struct /*class*/ /*IComparable*/ /*Employee - BaseClass*/  /*new()*/
    {
        public T X { get; set; }
        public T Y { get; set; }

        public Point2D()
        {
            X = default;
            Y = default;
        }
    }


    class Point3D<T> : Point2D<T> where T : struct
    {

    }


    class A<T>
    {
        public class B
        {

        }
    }

    class C<T>
    {
        public class D<T1>
        {

        }
    }

    
    class QPri<T> where T: IComparable<T> 
    {
        List<T> list;

        public QPri()
        {
            list = new();
        }

        public void Enqueue(T val)
        {
            list.Insert(1, val);
        }



    }



    static class ExtensiomMethod
    {

        public static string Mult(this string data, int n)
        {
            string res = "";
            for (int i = 0; i < n; i++)
            {
                res += data;
            }
            return res;
        }


        public static string PadCenter(this string data, int totalWidth)
        {
            int lenSpace = (totalWidth - data.Length <= 0) ? 0 : totalWidth - data.Length;
            return " ".Mult(lenSpace /2) + data + " ".Mult(lenSpace - lenSpace/2);
        }
    }

}
