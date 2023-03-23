using System;
using System.Linq;
using System.Text;

namespace PV221_CSharp
{
    internal class Program
    {
        enum Direction
        {
            Up, Down, Left, Right
        }

        public static void Func(ref int i, ref int[] arr, out int b)
        {
            Console.WriteLine(i);
            i = 999;
            Console.WriteLine(i);

            b = 888;

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            arr = new int[] { 55, 66, 77 };

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }


        public static int Sum(params int[] arr)
        {
            int s = 0;
            foreach (var item in arr)
            {
                s += item;
            }
            return s;
        }




        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "PV211";
            Console.Clear();




            ///////////////////////////
            //                       //  
            /////// 23.03.2023  ///////
            //                       //
            ///////////////////////////


            int a = 9;
            int b;
            int[] arr = { 1, 2, 3 };
            Func(ref a, ref arr, out b);

            Console.WriteLine(a);

            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.WriteLine( b);

            Console.WriteLine(  Sum(1,2, 3 ,4,5,6)  );


            //Student.SetPlanet("Mars");

            Student st;
            st = new Student();

            Console.WriteLine(st.Name);
            st.Name = "Oleg";

            //st.Print();
            //Console.WriteLine(st.group_id);
            //st.arr[0] = 100;

            //Console.WriteLine(Student.GetPlanet());
            //Console.WriteLine(Student.group);




            //Student p = new Student();
            //Student p2 = p;
            //p2.x = 10;
            //Console.WriteLine(p.x);



            //Direction direction = Direction.Down;
            //Console.WriteLine(direction);

            //Enum.GetNames(typeof(Direction));
            //var arr = Enum.GetValues(typeof(Direction));
            //foreach (Direction item in arr)
            //{
            //    Console.WriteLine( (int)item);
            //}




            //int a = Convert.ToInt32(Console.ReadLine());
            //int b = Convert.ToInt32(Console.ReadLine());
            //int c = a + b;
            //Console.WriteLine(c);


            //Console.WriteLine($"");

            //int d = 9;
            //if (d == 0)
            //{

            //}

            //string dd = "eee";

            //switch (dd)
            //{
            //    case "ddd":
            //        Console.WriteLine(0);
            //        break;
            //    case "er":
            //    case "fgfgfg":
            //        Console.WriteLine(1);
            //        break;
            //    default:
            //        break;
            //}

            //int mm = d > 10 ? 12 : 23;

            //int[] arr = new int[10];
            //Random random = new Random();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = random.Next(10, 30);
            //}

            ////while (true)
            ////{

            ////}

            ////do
            ////{

            ////} while (true);

            //foreach (var item in arr)
            //{
            //    Console.Write(item + " ");
            //}


            //DateTime dd = DateTime.Now;
            //Console.WriteLine(dd);
            //Console.WriteLine(dd.ToLongDateString());
            //Console.WriteLine(dd.ToLongTimeString());
            //Console.WriteLine(dd.ToShortDateString());
            //Console.WriteLine(dd.ToShortTimeString());
            //Console.WriteLine(dd.ToUniversalTime());
            //dd = Convert.ToDateTime(Console.ReadLine());
            //Console.WriteLine(dd);



            //int a = Int32.Parse(Console.ReadLine());
            //bool b = Int32.TryParse(Console.ReadLine(), out a);
            //if (b)
            //{
            //    Console.WriteLine(a);
            //}
            //else
            //{
            //    Console.WriteLine("Error");
            //}



            //int[] arr = new int[10] { 1, 2, 4, 6, 7, 5, 4, 3, 2, 1 };
            //int[] arr = { 1, 2, 4, 6, 7, 5, 4, 3, 2, 1 };
            //Array.Sort(arr);
            //foreach (var item in arr)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();

            //Console.WriteLine();

            //Console.WriteLine(Array.BinarySearch(arr, 6));


            //int[,] arr = new int[3, 4] { {1,2,3,4 },{ 5,6,7,8},{ 1,2,4,7} };
            //Console.WriteLine(arr.GetLength(0));
            //Console.WriteLine(arr.GetLength(1));
            //for (int i = 0; i < arr.GetLength(0); i++)
            //{
            //    for (int j = 0; j < arr.GetLength(1); j++)
            //    {
            //        Console.Write(arr[i,j] + " ");
            //    }
            //    Console.WriteLine();
            //}


            //int[][] arr = new int[4][];
            //arr[0] = new int[3];
            //arr[1] = new int[5];
            //arr[2] = new int[2];
            //arr[3] = new int[6];
            //Random random = new Random();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    for (int j = 0; j < arr[i].Length; j++)
            //    {
            //        arr[i][j] = random.Next(100, 900);
            //        Console.Write($"{arr[i][j]}".PadLeft(5));
            //    }
            //    Console.WriteLine( );
            //}

            //int[] arr1 = new int[10] { 1, 2, 4, 6, 7, 5, 4, 3, 2, 1 };
            //string st = "123+456";
            //Console.WriteLine(st.IndexOfAny("*-+/".ToCharArray()));
            //string[] arr = st.Split("*-+/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            //foreach (var item in arr)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(st.EndsWith("му"));
            //string ss = String.Join(", ", arr1);
            //Console.WriteLine(ss);

            //String sss = st;


            //StringBuilder sb = new StringBuilder();

        }
    }
}
