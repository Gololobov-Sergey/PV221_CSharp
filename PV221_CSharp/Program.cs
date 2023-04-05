using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using PV221_CSharp.CarNC;

//using static System.Console;

using NC4 = PV221_CSharp.CarNC.NC3;

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


        public static void Print(IIndex index, int ind)
        {
            Console.WriteLine(index[ind]);
        }


        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "PV211";
            Console.Clear();

            ///////////////////////////
            //                       //  
            /////// 04.04.2023  ///////
            //                       //
            ///////////////////////////



            Group pv221 = new Group();
            foreach (Student item in pv221)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine( );

            pv221.Sort(Student.FromBirthDay);

            foreach (Student item in pv221)
            {
                Console.WriteLine(item);
            }


            //Inter inter = new Inter();
            //inter.Show();
            //(inter as IA).Show();

            //IA ia = new Inter();
            //ia.Show();

            //IB ib = new Inter();
            //ib.Show();

            //IC ic = new Inter();
            //ic.Show();



            //Employee worker1 = new Manager();
            //Employee worker2 = new Brigadir();

            //List<Employee> workers = new List<Employee>();
            //workers.Add(worker1);
            //workers.Add(worker2);

            //foreach (var item in workers)
            //{

            //    if(item is IWorker)
            //    {
            //        IWorker w = item as IWorker;
            //        Console.WriteLine( w.IsWork);
            //        w.Work();
            //    }

            //    if(item is IManager)
            //    {
            //        IManager m = item as IManager;
            //        m.CreateReport();
            //        m.Control();
            //    }
            //}

            //Collection collection = new();

            //Console.WriteLine(collection[2]);

            //Print(collection, 2);

            ///////////////////////////
            //                       //  
            /////// 30.03.2023  ///////
            //                       //
            ///////////////////////////


            //Human e = new Employee("Egor", "Krutogolov", 50000);
            //Console.WriteLine(e);
            //e.Print();

            //Human director = new Director("Egor", "Krutogolov", 50000, 3);
            //Human[] employees = {
            //    director,
            //    new Economist("Olga", "Petrova", 30000, 10),
            //    new CleaningManager("Maria", "Ivanova", 10000, 100)
            //};


            //foreach (Human item in employees)
            //{
            //    Console.WriteLine(item);
            //    item.Dancing();


            //    //try
            //    //{
            //    //    ((Director)item).PrintSubordinate();
            //    //}
            //    //catch (Exception)
            //    //{
            //    //    Console.WriteLine("Not director");
            //    //}


            //    //Economist eco = item as Economist;
            //    //if(eco != null)
            //    //{
            //    //    eco.PrintExperience();
            //    //}
            //    //else
            //    //{
            //    //    Console.WriteLine("Not Economist");
            //    //}


            //    //if(item is CleaningManager)
            //    //{
            //    //    (item as CleaningManager).PrintCleaningArea();
            //    //}
            //    //else
            //    //{
            //    //    Console.WriteLine("Not CleaningManager");
            //    //}

            //    Console.WriteLine("=======================================");
            //    Console.WriteLine();
            //}

            //Console.WriteLine(director.GetType().BaseType);
            //var s = director.GetType().GetMethods();
            //foreach (var item in s)
            //{
            //    Console.WriteLine(item);
            //}

            //var s1 = director.GetType().GetConstructors();
            //foreach (ConstructorInfo item in s1)
            //{
            //    Console.WriteLine(item);
            //}

            //var s2 = director.GetType().GUID;
            //Console.WriteLine(s2);
            //foreach (ConstructorInfo item in s1)
            //{
            //    Console.WriteLine(item);
            //}

            ///////////////////////////
            //                       //  
            /////// 29.03.2023  ///////
            //                       //
            ///////////////////////////


            //Point p = new Point { X = 10, Y = 15 };
            //p.Print();
            //Point p2 = -p;
            //p2.Print();

            //p2++;
            //p2.Print();

            //++p2;
            //p2.Print();

            //(+p2).Print();

            //(++p2).Print();

            //Point p1 = new Point { X = 3, Y = 5 };

            //Point p3 = p + p1;
            //p3.Print();

            //p += p1; // p = p + p1;
            //p.Print();

            //p3 = p + 44;
            //p3 = 44 + p;

            //p += 44;



            //Point p = new Point { X = 10, Y = 15 };
            //Point p1 = p;
            //Console.WriteLine(ReferenceEquals(p, p1));
            //Console.WriteLine(p.Equals(p1));

            //Console.WriteLine(p1);

            //if(p1 && p)
            //{
            //    Console.WriteLine(p);
            //}

            //bool b = (bool)p1;

            //double d = p;

            //p = 10;

            //Stud st = new Stud();
            //p = (Point)st;

            //string st = null;
            //int? c = null;
            //Console.WriteLine(c);
            //c = c ?? 30;


            //Polygon p = new Polygon(5);
            //Console.WriteLine(p);
            //Console.WriteLine(p["one"]);
            //p[3] = new Point { X = 4, Y = 5 };
            //Console.WriteLine(p["one"]);
            ////p["one"] = new Point { X = 5, Y = 6 };


            //Matrix m = new(3, 4);
            //Console.WriteLine(m[2,2]);
            //m[2, 1] = 100;


            ///////////////////////////
            //                       //  
            /////// 28.03.2023  ///////
            //                       //
            ///////////////////////////

            //Stud st = new Stud()
            //{
            //    FirstName = "Oleg",
            //    LastName = "Zubkov",
            //    Group = "PV221"
            //};


            //st.AddMark(course: Course.Admin, mark: 12);
            //st.AddMark(course: Course.Programm, mark: 11);
            //st.AddMark(course: Course.Programm, mark: 10);
            //st.AddMark(course: Course.Design, mark: 12);
            //st.AddMark(course: Course.Programm, mark: 8);
            //st.AddMark(course: Course.Admin, mark: 10);

            //Print(st, 2);

            //st.Info();

            //Console.WriteLine(st.GetLastMark(Course.Programm));

            //Console.WriteLine(Math.Round(st.GetAvarageCourse(Course.Programm), 1));

            //st[Course.Programm] = "9";

            //Console.WriteLine(st[Course.Programm]);

            //Car car = new Car() 
            //{ 
            //    Vendor = "BMW", 
            //    Model = "X7", 
            //    Year = 2023
            //};

            //car.Print();

            //CarNC.NC3.CargoCar cc = new();
            //NC4.CargoCar ccc = new();


            ///////////////////////////
            //                       //  
            /////// 23.03.2023  ///////
            //                       //
            ///////////////////////////


            //int a = 9;
            //int b;
            //int[] arr = { 1, 2, 3 };
            //Func(ref a, ref arr, out b);

            //Console.WriteLine(a);

            //foreach (var item in arr)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine();

            //Console.WriteLine( b);

            //Console.WriteLine(  Sum(1,2, 3 ,4,5,6)  );


            ////Student.SetPlanet("Mars");

            //Student st;
            //st = new Student();

            //Console.WriteLine(st.Name);
            //st.Name = "Oleg";

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
