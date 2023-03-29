using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV221_CSharp
{
    internal class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public static Point operator -(Point p)
        {
            return new Point { X = -p.X, Y = -p.Y };
        }

        public static Point operator +(Point p)
        {
            return new Point { X = ++p.X, Y = ++p.Y };
        }

        public static Point operator ++(Point p)
        {
            p.X += 2;
            p.Y += 2;
            return p;
        }


        public static Point operator +(Point p1, Point p2)
        {
            return new Point { X = p1.X + p2.X, Y = p1.Y + p2.Y };
        }


        public static Point operator +(Point p1, int n)
        {
            return new Point { X = p1.X + n, Y = p1.Y + n };
        }

        public static Point operator +( int n, Point p1)
        {
            return p1 + n;
        }


        public override bool Equals(object obj)
        {
            return this.X == ((Point)obj).X && this.Y == ((Point)obj).Y;
        }


        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }


        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }


        public static bool operator >(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X, 2) + Math.Pow(p1.Y, 2)) > 
                Math.Sqrt(Math.Pow(p2.X, 2) + Math.Pow(p2.Y, 2));
        }

        public static bool operator <(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X, 2) + Math.Pow(p1.Y, 2)) <
                Math.Sqrt(Math.Pow(p2.X, 2) + Math.Pow(p2.Y, 2));
        }

        public override string ToString()
        {
            return $"X = {X}, Y = {Y}";
        }


        public static bool operator true(Point p)
        {
            return p.X !=0 || p.Y != 0 ? true: false ;
        }


        public static bool operator false(Point p)
        {
            return p.X == 0 && p.Y == 0 ? true : false;
        }


        public static Point operator &(Point p1, Point p2)
        {
            return new Point();
        }


        public static explicit /*implicit*/ operator bool(Point p)
        {
            return p.X == 0 && p.Y == 0 ? false : true;
        }


        public static explicit /*implicit*/ operator double(Point p)
        {
            return Math.Sqrt(Math.Pow(p.X, 2) + Math.Pow(p.Y, 2));
        }

        public static /*explicit*/ implicit operator Point(double p)
        {
            return new Point();
        }

        public static explicit operator Point(Stud v)
        {
            throw new NotImplementedException();
        }
    }


    class Polygon
    {
        Point[] points;

        public Polygon(int count)
        {
            points = new Point[count];
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                points[i] = new Point { X = random.Next(10), Y = random.Next(10) };
            }
        }

        public override string ToString()
        {
            string s = "";
            foreach (Point p in points)
            {
                s += p.ToString() + "\n";
            }
            return s;
        }


        public Point this[int index]
        {
            get 
            {
                if(index >= 0 && index < points.Length)
                    return points[index];
                throw new IndexOutOfRangeException();
            }
            set 
            {
                if (index >= 0 && index < points.Length)
                    points[index] = value;
            }
        }


        public Point this[string name]
        {
            get
            {
                int i = 0;
                switch (name)
                {
                    case "zero": i = 0; break;
                    case "one": i = 1; break;
                    case "two": i = 2; break;
                    case "three": i = 2; break;
                    default:
                        break;
                }
                return points[i];
            }
        }

    }


    class Matrix
    {
        int[,] arr;

        public int Rows { get; private set; }
        public int Column { get; private set; }

        public Matrix(int r, int c)
        {
            Rows = r;
            Column = c;
            arr = new int[r, c];
        }

        public int this[int r, int c]
        {
            get { return arr[r, c]; }
            set { arr[r, c] = value; }
        }
    }

}
