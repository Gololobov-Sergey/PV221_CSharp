using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Xml;
using System.Xml.Serialization;
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


        public static int Div(int a, int b)
        {
            int res = 0;
            try
            {
                if (b == 0)
                    throw new MyException();
                res = a / b;
            }
            catch (DivideByZeroException e)
            {
                throw new Exception("Not result", e);
            }
            return res;
        }



        static void PrintStudents(Hashtable group)
        {
            foreach (Student item in group.Keys)
            {
                Console.WriteLine(item + ", Marks: " + string.Join(",", (group[item] as ArrayList).ToArray()));
            }
        }


        static void AddMark(Hashtable table, string LastName, string FirstName, int mark)
        {
            foreach (Student item in table.Keys)
            {
                if (item.FirstName == FirstName && item.LastName == LastName)
                {
                    (table[item] as ArrayList).Add(mark);
                }
            }
        }


        static T MaxValue<T>(T[] arr) where T : IComparable<T>
        {
            T max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].CompareTo(max) > 0)
                {
                    max = arr[i];
                }
            }
            return max;
        }

        public static void PrintHello()
        {
            Console.WriteLine("Hello");
        }

        // modifer delegate type nameDelegate (param);

        public delegate void VoidDelegate();

        public delegate int IntDelegate(int a, int b);

        public delegate T T_Delegate1<T>(T a, T b);

        //public delegate void T_Delegate<T1>(T1 a);
        //public delegate void T_Delegate<T1, T2>(T1 a, T2 b);
        //public delegate void T_Delegate<T1, T2, T3>(T1 a, T2 b, T3 c);
        public delegate TResult T_Delegate<T1, TResult>(T1 a);

        public static void PrintFirstLastName(Student student)
        {
            Console.WriteLine($"{student.LastName} {student.FirstName}");
        }


        public static string SelectFirstLastName(Student student)
        {
            return $"{student.LastName} {student.FirstName}";
        }


        public static bool AllBirthDay1998(Student student)
        {
            return student.BirthDay.Year > 1998;
        }

        public static bool AgeValid(Student student)
        {
            var list = typeof(Student).GetProperties()
                .ToList()
                .Find(a => a.Name == "BirthDay");

            foreach (var item in list.GetCustomAttributes())
            {
                if (item is AgeValidationAttribute)
                {
                    return (DateTime.Now - student.BirthDay).Days / 365.25 > (item as AgeValidationAttribute).Age;
                }
            }
            return false;
        }


        //modify event NameDelegate NameEvent;


        static void printNode(XmlNode node)
        {
            Console.WriteLine($"{node.NodeType}".PadRight(15) + $"{node.Name}".PadRight(15) + $"{node.Value}".PadRight(15));
            
            if(node.Attributes != null)
            {
                foreach (XmlNode item in node.Attributes)
                {
                    Console.WriteLine($"{item.NodeType}".PadRight(15) + $"{item.Name}".PadRight(15) + $"{item.Value}".PadRight(15));
                }
            }

            if(node.HasChildNodes)
            {
                foreach (XmlNode item in node.ChildNodes)
                {
                    printNode(item);
                }
            }
        }



        static void Main(string[] args)
        {

            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Title = "PV211";
            Console.Clear();

            ///////////////////////////
            //                       //  
            /////// 26.04.2023  ///////
            //                       //
            ///////////////////////////

            //// XML //////
            ///
            // DOM
            //============================================================


            XmlDocument xml = new XmlDocument();
            xml.Load("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange");
            //printNode(xml.DocumentElement);

            var name = xml.GetElementsByTagName("txt");
            var rate = xml.GetElementsByTagName("rate");
            for (int i = 0; i < name.Count; i++)
            {
                if (Convert.ToDecimal(rate[i].InnerText.Replace('.', ',')) > 20M)
                {
                    Console.WriteLine($"{name[i].InnerText.PadRight(30)} {rate[i].InnerText}");
                }
            }


            //XmlDocument xml = new XmlDocument();
            //xml.Load("Computers.xml");
            //XmlNode root = xml.DocumentElement;

            ////printNode(xml.DocumentElement);


            //XmlNode comp = xml.CreateElement("Computer");
            //XmlAttribute attr = xml.CreateAttribute("Type");
            //attr.Value = "Office";
            //comp.Attributes.Append(attr);

            //XmlNode comp1 = xml.CreateElement("Motheboard");
            //XmlNode comp2 = xml.CreateElement("Processor");
            //XmlNode comp3 = xml.CreateElement("RAM");
            //XmlNode comp4 = xml.CreateElement("SSD");
            //XmlNode comp5 = xml.CreateElement("Video");

            //XmlNode text1 = xml.CreateTextNode("Gigabyte");
            //XmlNode text2 = xml.CreateTextNode("Intel Celeron");
            //XmlNode text3 = xml.CreateTextNode("8Gb");
            //XmlNode text4 = xml.CreateTextNode("128Gb");
            //XmlNode text5 = xml.CreateTextNode("Integred");

            //comp1.AppendChild(text1);
            //comp2.AppendChild(text2);
            //comp3.AppendChild(text3);
            //comp4.AppendChild(text4);
            //comp5.AppendChild(text5);

            //comp.AppendChild(comp1);
            //comp.AppendChild(comp2);
            //comp.AppendChild(comp3);
            //comp.AppendChild(comp4);
            //comp.AppendChild(comp5);

            //root.AppendChild(comp);

            //xml.Save("Computers.xml");


            //  SAX 
            //============================================================
            //XmlTextWriter xml = new XmlTextWriter("Computers.xml", Encoding.Unicode);
            //xml.Formatting = Formatting.Indented;
            //xml.WriteStartDocument();
            //xml.WriteStartElement("Computers");
            /////
            //    xml.WriteStartElement("Computer");
            //        xml.WriteAttributeString("Type", "Home");
            //        xml.WriteElementString("Motheboard", "MSI");
            //        xml.WriteElementString("Processor", "Intel Core i5");
            //        xml.WriteElementString("RAM", "64Gb");
            //        xml.WriteElementString("SSD", "512Gb");
            //        xml.WriteElementString("Video", "Radeon");
            //    xml.WriteEndElement();

            //    xml.WriteStartElement("Computer");
            //        xml.WriteAttributeString("Type", "Game");
            //        xml.WriteElementString("Motheboard", "ASUS");
            //        xml.WriteElementString("Processor", "AMD Razen 7");
            //        xml.WriteElementString("RAM", "128Gb");
            //        xml.WriteElementString("SSD", "4Tb");
            //        xml.WriteElementString("Video", "NVidia");
            //    xml.WriteEndElement();

            //xml.WriteEndElement();
            //xml.Close();    



            //XmlTextReader xml = new XmlTextReader("Computers.xml");
            //xml.WhitespaceHandling = WhitespaceHandling.None;

            //while(xml.Read())
            //{
            //    Console.WriteLine($"{xml.NodeType.ToString().PadRight(15)} {xml.Name.ToString().PadRight(15)} {xml.Value.ToString().PadRight(15)}");
            //    if(xml.AttributeCount > 0)
            //    {
            //        while(xml.MoveToNextAttribute())
            //        {
            //            Console.WriteLine($"{xml.NodeType.ToString().PadRight(15)} {xml.Name.ToString().PadRight(15)} {xml.Value.ToString().PadRight(15)}");
            //        }
            //    }
            //}


            //================================================================


            //List<string> typeComp = new List<string>();

            //while (xml.Read())
            //{
            //    if (xml.NodeType == XmlNodeType.Element && xml.Name == "Computer" && xml.HasAttributes)
            //    {
            //        while(xml.MoveToNextAttribute()) 
            //        { 
            //            if(xml.Name == "Type")
            //            {
            //                if (!typeComp.Contains(xml.Value))
            //                {
            //                    typeComp.Add(xml.Value);
            //                }
            //            }
            //        }
            //    }
            //}

            //typeComp.ForEach(comp => { Console.WriteLine(comp); });

            // typeComp.Distinct();







            ///////////////////////////
            //                       //  
            /////// 25.04.2023  ///////
            //                       //
            ///////////////////////////


            //foreach (var item in typeof(Student).GetCustomAttributes())
            //{
            //    Console.WriteLine(item);
            //}


            //foreach (MethodInfo item in typeof(Student).GetMethods())
            //{
            //    Console.WriteLine(item.Name);
            //    foreach (var a in item.GetCustomAttributes())
            //    {
            //        Console.WriteLine(a);
            //    }
            //}

            //typeof(Student).GetCustomAttributes()
            //    .ToList()
            //    .FindAll(a => (a as ProgrammerAttribute).Date.Month == 4)
            //    .ForEach(p => Console.WriteLine(p));


            //List<Student> group = new List<Student>
            //{
            //    new Student()
            //    {
            //        LastName = "Osipov",
            //        FirstName = "Oleg",
            //        BirthDay = new DateTime(2000, 12, 15),
            //        StudentCard = new StudentCard()
            //        {
            //            Series = "AB",
            //            Number = 123456
            //        }
            //    },

            //    new Student()
            //    {
            //        LastName = "Petrova",
            //        FirstName = "Maria",
            //        BirthDay = new DateTime(2002, 04, 20),
            //        StudentCard = new StudentCard()
            //        {
            //            Series = "AB",
            //            Number = 129956
            //        }
            //    },

            //    new Student()
            //    {
            //        LastName = "Fedorov",
            //        FirstName = "Petro",
            //        BirthDay = new DateTime(1999, 01, 10),
            //        StudentCard = new StudentCard()
            //        {
            //            Series = "AC",
            //            Number = 123456
            //        }
            //    },

            //    new Student()
            //    {
            //        LastName = "Abramova",
            //        FirstName = "Olga",
            //        BirthDay = new DateTime(2005, 12, 14),
            //        StudentCard = new StudentCard()
            //        {
            //            Series = "AA",
            //            Number = 124123
            //        }
            //    }
            //};


            //XmlSerializer xml = new(typeof(List<Student>));
            //using (Stream stream = File.Create("students11.xml"))
            //{
            //    xml.Serialize(stream, group);
            //}


            //List<Student> st;
            //using (Stream stream = File.OpenRead("students11.xml"))
            //{
            //   st = (List<Student>)xml.Deserialize(stream);
            //}
            //foreach (var item in st)
            //{
            //    Console.WriteLine(item);
            //}

            //================================================

            //BinaryFormatter bf = new BinaryFormatter();
            //using (Stream stream = File.Create("students11.bin"))
            //{
            //    bf.Serialize(stream, group);
            //}


            //List<Student> st;
            //using (Stream stream = File.OpenRead("students11.bin"))
            //{
            //    st = (List<Student>)bf.Deserialize(stream);
            //}

            //foreach (var item in st)
            //{
            //    Console.WriteLine(item);
            //}


            //Student st = null;
            //using (Stream stream = File.OpenRead("student.bin"))
            //{
            //    st = (Student)bf.Deserialize(stream);
            //}

            //Console.WriteLine(st);

            //===================================================



            //foreach (var item in group)
            //{
            //    Console.WriteLine(AgeValid(item));
            //}


            ///////////////////////////
            //                       //  
            /////// 20.04.2023  ///////
            //                       //
            ///////////////////////////

            // .
            // \w - 
            // \W
            // \s
            // \S
            // \d
            // \D
            // [abc]
            // +


            //string pattern = @"^([A-Z][a-z]*\s?-?){3,}$";
            //string pattern = @"^(\d{1,3}.){3}\d{1,3}$";
            //string pattern = @"^(\d{1,2}.){2}\d{4}$";
            //string pattern = @"^\+38\(0(50|66)\)\d{3}-\d{2}-\d{2}$";

            //Regex regex = new Regex(pattern); 

            //while (true)
            //{
            //    string str = Console.ReadLine();
            //    Console.WriteLine(regex.IsMatch(str));
            //}

            //int[] arr = { 3, 5, 2, 23, 5, 7, 89, 873, 54, 3, 33, 56 };

            //var res = from i in arr.Where(x => x % 10 == 3)
            //          group i by (int)(Math.Log10(i) + 1);



            ////var res1 = arr.Where(i => i > 20);

            //foreach (var item in res)
            //{
            //    Console.Write(item.Key + " : ");
            //    foreach (var item2 in item)
            //    {
            //        Console.Write(item2 + " ");
            //    }
            //    Console.WriteLine();
            //}



            //arr[2] = 999;


            //foreach (var item in res1)
            //{
            //    Console.Write(item + " ");
            //}

            ///////////////////////////
            //                       //  
            /////// 19.04.2023  ///////
            //                       //
            ///////////////////////////

            //using (FileStream fs = new("file1.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            //{
            //    string str = Console.ReadLine();
            //    byte[] bytes = Encoding.Default.GetBytes(str);
            //    fs.Write(bytes, 0, bytes.Length);
            //}

            //using (FileStream fs = new("file1.bin", FileMode.Open, FileAccess.Read, FileShare.Read))
            //{
            //    byte[] bytes = new byte[fs.Length];
            //    fs.Read(bytes, 0, bytes.Length);
            //    string str = Encoding.Default.GetString(bytes);
            //    Console.WriteLine(str);
            //}




            //using (FileStream fs = new("file2.txt", FileMode.CreateNew))
            //{
            //    using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
            //    {
            //        string str = Console.ReadLine();
            //        sw.WriteLine(str);
            //        foreach (var item in str)
            //        {
            //            sw.Write(item + ".");
            //        }
            //        sw.WriteLine();
            //    }
            //}

            //using (FileStream fs = new("file2.txt", FileMode.Open))
            //{
            //    using(StreamReader sr = new StreamReader(fs, Encoding.Unicode)) 
            //    {
            //        string str = sr.ReadToEnd();
            //        Console.WriteLine( str);
            //    }
            //}


            //using (FileStream fs = new("file3.bin", FileMode.CreateNew))
            //{
            //    using (BinaryWriter bw = new BinaryWriter(fs, Encoding.Unicode))
            //    {
            //        int n = 1234;
            //        string str = "Вінниця і Миколаїв";
            //        double pi = 3.141592;

            //        bw.Write(n);
            //        bw.Write(str);
            //        bw.Write(pi);
            //    }
            //}

            //using (FileStream fs = new("file3.bin", FileMode.Open))
            //{
            //    using (BinaryReader br = new BinaryReader(fs, Encoding.Unicode))
            //    {
            //        int n = br.ReadInt32();
            //        string s = br.ReadString();
            //        double d = br.ReadDouble();                 

            //        Console.WriteLine(n);
            //        Console.WriteLine(s);
            //        Console.WriteLine(d);
            //    }
            //}

            //DirectoryInfo dir = new DirectoryInfo(".");
            //dir.CreateSubdirectory("Dir1");
            //Console.WriteLine(dir.FullName);
            //Console.WriteLine(dir.Name);
            //Console.WriteLine(dir.Parent);
            //Console.WriteLine(dir.Attributes);
            //Console.WriteLine(dir.CreationTime);
            //Console.WriteLine(dir.Exists);

            //List<string> list = new List<string>(); 
            //var dirs = dir.GetDirectories();
            //foreach (var item in dirs)
            //{
            //    list.Add(item.Name);
            //}

            //var files = dir.GetFiles();
            //foreach (var item in files)
            //{
            //    list.Add(item.Name);
            //}

            //ConsoleMenu.SelectVertical(HPosition.Left, VPosition.Top, HorizontalAlignment.Left, list);
            //ConsoleMenu.SelectVertical(HPosition.Left, VPosition.Top, HorizontalAlignment.Left, "srgerg", "sdfgh", "sdfg");

            //using(StreamWriter sw = File.CreateText("text4.txt"))
            //{
            //    sw.WriteLine("kldsfj wloejflwekjf wef");
            //}

            //using (StreamReader sr = File.OpenText("text4.txt"))
            //{
            //    Console.WriteLine(sr.ReadToEnd());
            //}

            //FileInfo file = new FileInfo("text4.txt");
            //Console.WriteLine(file.FullName);
            //Console.WriteLine(file.Name);

            //Console.WriteLine(file.Length);
            //Console.WriteLine(file.CreationTime);
            //Console.WriteLine(file.Attributes & FileAttributes.System);
            //Console.WriteLine(file.Directory.FullName);
            //Console.WriteLine(file.Extension.TrimStart('.'));
            //Console.WriteLine(file.LastAccessTime);
            //Console.WriteLine(file.LastWriteTime);

            //Directory.GetLogicalDrives().ToList().ForEach(x => Console.WriteLine(x));

            ///////////////////////////
            //                       //  
            /////// 18.04.2023  ///////
            //                       //
            ///////////////////////////

            //VoidDelegate vd = new VoidDelegate(PrintHello);
            //vd();
            //vd += delegate () { Console.WriteLine("Godbye"); };
            //vd += () => Console.WriteLine("Godbye");
            //vd();

            //IntDelegate id = null;

            //id += delegate (int c, int d) { return c + d; };

            //id += (c, d) => c - d;

            //Console.WriteLine(id(3,5));

            // (param) => { code };


            ///////////////////////////
            //                       //  
            /////// 13.04.2023  ///////
            //                       //
            ///////////////////////////




            //VoidDelegate vd = new VoidDelegate(PrintHello);
            //vd();

            //Calc calc = new();

            //CalcDelegate calcDelegate = calc.Sum;
            //calcDelegate += calc.Sub;
            //calcDelegate += Calc.Mult;
            //calcDelegate += calc.Div;

            //string expresson = Console.ReadLine();
            ////2 + 3
            //string[] strings = expresson.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            //switch (strings[1])
            //{
            //    case "+":
            //        calcDelegate = new CalcDelegate(calc.Sum); break;
            //    case "-":
            //        calcDelegate = new CalcDelegate(calc.Sub); break;
            //    case "*":
            //        calcDelegate = Calc.Mult; break;
            //    case "/":
            //        calcDelegate = calc.Div; break;
            //    default:
            //        break;
            //}

            //foreach (CalcDelegate item in calcDelegate.GetInvocationList())
            //{
            //    double result = item(double.Parse(strings[0]), double.Parse(strings[2]));

            //    Console.WriteLine(result);
            //}



            //Action<Hashtable> aaa = PrintStudents;
            //T_Delegate<int> intDel = Div;
            //T_Delegate<double> doubleDel;


            //List<Student> group = new List<Student>
            //{
            //    new Student()
            //    {
            //        LastName = "Osipov",
            //        FirstName = "Oleg",
            //        BirthDay = new DateTime(2000, 12, 15),
            //        StudentCard = new StudentCard()
            //        {
            //            Series = "AB",
            //            Number = 123456
            //        }
            //    },

            //    new Student()
            //    {
            //        LastName = "Petrova",
            //        FirstName = "Maria",
            //        BirthDay = new DateTime(2002, 04, 20),
            //        StudentCard = new StudentCard()
            //        {
            //            Series = "AB",
            //            Number = 129956
            //        }
            //    },

            //    new Student()
            //    {
            //        LastName = "Fedorov",
            //        FirstName = "Petro",
            //        BirthDay = new DateTime(1999, 01, 10),
            //        StudentCard = new StudentCard()
            //        {
            //            Series = "AC",
            //            Number = 123456
            //        }
            //    },

            //    new Student()
            //    {
            //        LastName = "Abramova",
            //        FirstName = "Olga",
            //        BirthDay = new DateTime(2000, 12, 14),
            //        StudentCard = new StudentCard()
            //        {
            //            Series = "AA",
            //            Number = 124123
            //        }
            //    }
            //};


            //var res = from s in @group
            //          where s.BirthDay == (from d in @group select d.BirthDay).Max()
            //          select s; // new { LN = s.LastName, BD = s.BirthDay };

            //var res1 = group.Where(s => s.FirstName.First() == 'O');

            //foreach (var item in res)
            //{
            //    Console.WriteLine(item);
            //}



            //group.ForEach(s => Console.WriteLine(s));
            //Console.WriteLine();

            //group
            //    .FindAll(s => s.BirthDay.Month >=3 &&  s.BirthDay.Month <= 5)
            //    .ForEach(s => Console.WriteLine(s));
            //Console.WriteLine();


            //Console.WriteLine(group.Find(s => s.BirthDay == group.Max(s => s.BirthDay)));

            //group.Sort(Student.FromBirthDay);
            //Console.WriteLine(group.Last());

            //string st = "Hello";
            //Console.WriteLine(st.PadLeft(10));
            //Console.WriteLine(st.PadRight(10));
            //Console.WriteLine(st.PadCenter(10));

            //Teacher teacher = new();
            //foreach (Student item in group)
            //{
            //    teacher.ExamEvent += item.Exam;
            //}

            //teacher.Exam(new DateTime(2023, 4, 18));
            //teacher.Exam(new ExamEventArgs
            //{
            //    DateExam = new DateTime(2023, 4, 14),
            //    Subject = "C#",
            //    Room = "305A"
            //});

            //teacher.ExamEvent -= group[1].Exam;

            //teacher.Exam(new DateTime(2023, 4, 25)); 

            //teacher.Exam(new ExamEventArgs
            //{
            //    DateExam = new DateTime(2023, 4, 20),
            //    Subject = "C#",
            //    Room = "307A"
            //});

            //teacher.ExamEvent1 += Teacher_ExamEvent1;

            //group.ForEach(PrintFirstLastName);

            //Console.WriteLine(group.All(s => s.BirthDay.Year > 1998));


            //var FullName = group.Select(SelectFirstLastName);
            //foreach (var item in FullName)
            //{
            //    Console.WriteLine(item);
            //}

            //var gr = group
            //    .GroupBy(s => s.StudentCard.Series)
            //    .OrderBy(g => g.Key);

            //foreach (var item in gr)
            //{
            //    Console.WriteLine("Series: " + item.Key);
            //    foreach (var item1 in item)
            //    {
            //        Console.WriteLine(item1);
            //    }
            //}

            //var list2000 = group.FindAll(s => s.BirthDay.Year == 2000);
            //list2000.ForEach(s => Console.WriteLine(s));


            //group.Sort((s1, s2) => s1.BirthDay.CompareTo(s2.BirthDay));
            //group.ForEach(s => Console.WriteLine(s));


            ///////////////////////////
            //                       //  
            /////// 12.04.2023  ///////
            //                       //
            ///////////////////////////


            //int[] arr = { 2, 56, 8, 54, 3, 5, 7, 8, 43 };
            //Console.WriteLine(MaxValue(arr));

            // int(*name)(int, int) = func;
            // name();

            // vector<type(*name)(param)> v;


            //A<int>.B aa = new();

            //C<int>.D<string> ddd = new();


            //Point2D<Director> p = new();
            //Console.WriteLine(typeof(Point2D<int>));




            //Dictionary<string, int> dic = new()
            //{
            //    { "one", 1 },
            //    { "three", 3 },
            //    { "two", 2 }
            //};

            //Console.WriteLine(dic.TryAdd("oniuyte", 1));

            //foreach (var item in dic.Keys)
            //{
            //    Console.WriteLine(item + " " + dic[item]);
            //}




            ///////////////////////////
            //                       //  
            /////// 11.04.2023  ///////
            //                       //
            ///////////////////////////


            //using (new OperationTimer("ArrayList"))
            //{
            //    ArrayList arrayList = new ArrayList();
            //    for (int i = 0; i < 10000000; i++)
            //    {
            //        arrayList.Add(i);
            //        int val = (int)arrayList[i];
            //    }
            //    arrayList = null;
            //}


            //using (new OperationTimer("List<int>"))
            //{
            //    List<int> list = new List<int>();

            //    for (int i = 0; i < 10000000; i++)
            //    {
            //        list.Add(i);
            //        int val = list[i];
            //    }
            //    list = null;
            //}




            //Hashtable group1 = new Hashtable
            //Dictionary<Student, ArrayList> group1 = new Dictionary<Student, ArrayList>
            //{
            //    {
            //        new Student()
            //        {
            //            LastName = "Osipov",
            //            FirstName = "Oleg",
            //            BirthDay = new DateTime(2000, 12, 15),
            //            StudentCard = new StudentCard()
            //            {
            //                Series = "AB",
            //                Number = 123456
            //            }
            //        },
            //        new ArrayList{10, 12, 11}
            //    },
            //    {
            //        new Student()
            //        {
            //            LastName = "Petrova",
            //            FirstName = "Maria",
            //            BirthDay = new DateTime(2002, 04, 20),
            //            StudentCard = new StudentCard()
            //            {
            //                Series = "AB",
            //                Number = 129956
            //            }
            //        },
            //        new ArrayList{9, 10, 11}
            //    },
            //    {
            //        new Student()
            //        {
            //            LastName = "Fedorov",
            //            FirstName = "Petro",
            //            BirthDay = new DateTime(1999, 01, 10),
            //            StudentCard = new StudentCard()
            //            {
            //                Series = "AC",
            //                Number = 123456
            //            }
            //        },
            //        new ArrayList{12, 12, 11}
            //    },
            //    {
            //        new Student()
            //        {
            //            LastName = "Abramova",
            //            FirstName = "Olga",
            //            BirthDay = new DateTime(2000, 12, 14),
            //            StudentCard = new StudentCard()
            //            {
            //                Series = "AA",
            //                Number = 123451
            //            }
            //        },
            //        new ArrayList{6, 8, 7}
            //    }
            //};

            //XmlSerializer serializer = new XmlSerializer(typeof(Dictionary<Student, ArrayList>));
            //using(Stream s = File.Create("st.xml"))
            //{
            //    serializer.Serialize(s, group1 );
            //}

            //PrintStudents(group);

            //AddMark(group, "Abramova", "Olga", 10);

            //AddMark(group, "Abramova", "Svitlana", 10);

            //Console.WriteLine();

            //PrintStudents(group);

            //SortedList sortedList = new();

            //sortedList.Add(10, "one");
            //sortedList.Add(2, "two");
            //sortedList.Add(1, new Student());
            //foreach (var item in sortedList.Keys)
            //{
            //    Console.WriteLine($"Key: {item}, Value: {sortedList[item]}");
            //}



            //Hashtable hashtable = new Hashtable();
            //hashtable.Add(1, "one");
            //hashtable.Add("two", 2);
            //hashtable.Add(new Student(), DateTime.Now);

            //foreach (var item in hashtable.Keys)
            //{
            //    Console.WriteLine($"Key: {item}, Value: {hashtable[item]}");
            //}




            //Queue queue = new Queue(); 




            //Stack stack = new();
            //stack.Push(100);
            //stack.Push("sfgh");
            //stack.Push(new Student());
            //foreach (var item in stack)
            //{
            //    Console.WriteLine(item);
            //}


            //ArrayList arrayList = new ArrayList(10);
            //arrayList.Add(100);
            //arrayList.Add("dsfsgh");
            ////arrayList.Add(new Student());
            //arrayList.AddRange(new object[] { "sdfg", 234, DateTime.Now });
            //Console.WriteLine(arrayList.Capacity);

            //foreach (var item in arrayList)
            //{
            //    Console.WriteLine(item);
            //}

            //arrayList.TrimToSize();
            //Console.WriteLine(arrayList.Capacity);

            //Console.WriteLine(arrayList.LastIndexOf("sdfg"));


            ///////////////////////////
            //                       //  
            /////// 06.04.2023  ///////
            //                       //
            ///////////////////////////


            //string s = Console.ReadLine();

            //int num = 0;
            //if (s.All(c => c == '0' || c == '1'))
            //{
            //    for (int i = 0; i < s.Length; i++)
            //    {
            //        num += (s[s.Length - i - 1] - 48) * (int)Math.Pow(2, i);
            //    }
            //}
            //Console.WriteLine(num);

            //GarbageGenerator gg = new GarbageGenerator();
            //try
            //{
            //    gg.CreateGarbage();
            //}
            //finally
            //{
            //    gg.Dispose();
            //}


            //using(GarbageGenerator gg1 = new GarbageGenerator())
            //{
            //    gg1.CreateGarbage();
            //}



            //Console.WriteLine("Max Gen: " + GC.MaxGeneration);

            //GarbageGenerator gg = new GarbageGenerator();

            //Console.WriteLine("Gen obj: " + GC.GetGeneration(gg));
            //Console.WriteLine("Memory: " + GC.GetTotalMemory(false));

            //gg.CreateGarbage();

            //Console.WriteLine("Gen obj: " + GC.GetGeneration(gg));
            //Console.WriteLine("Memory: " + GC.GetTotalMemory(false));

            //GC.Collect(0);

            //Console.WriteLine("Gen obj: " + GC.GetGeneration(gg));
            //Console.WriteLine("Memory: " + GC.GetTotalMemory(false));

            //GC.Collect();

            //Console.WriteLine("Gen obj: " + GC.GetGeneration(gg));
            //Console.WriteLine("Memory: " + GC.GetTotalMemory(false));

            //GC.Collect();

            //Console.WriteLine("Gen obj: " + GC.GetGeneration(gg));
            //Console.WriteLine("Memory: " + GC.GetTotalMemory(false));

            //byte b = 100;

            //try
            //{

            //    b = (byte)(b + 200);

            //    Console.WriteLine(b);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}





            //int n1, n2, res;

            //try
            //{
            //    n1 = Convert.ToInt32(Console.ReadLine());
            //    n2 = Convert.ToInt32(Console.ReadLine());
            //    res = Div(n1, n2);
            //    Console.WriteLine(res);
            //}
            //catch (Exception e) /*when (e.InnerException != null)*/
            //{
            //    Console.WriteLine(e.Message);
            //    Console.WriteLine(e.StackTrace);
            //    Console.WriteLine(e.Source);
            //    Console.WriteLine(e.HResult);
            //    Console.WriteLine(e.TargetSite);
            //    foreach (var item in e.Data.Keys)
            //    {
            //        Console.WriteLine(item + ": " + e.Data[item]);
            //    }
            //    //Console.WriteLine(e.InnerException.Message);
            //}




            ///////////////////////////
            //                       //  
            /////// 05.04.2023  ///////
            //                       //
            ///////////////////////////


            //try
            //{
            //    throw new NotImplementedException();
            //    int c = 5;
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine( e.Message);
            //    Console.WriteLine( e.StackTrace);
            //    Console.WriteLine( e.Source);
            //    Console.WriteLine( e.HResult);
            //    Console.WriteLine( e.TargetSite);
            //}
            //finally
            //{

            //}






            //MyArray a = new MyArray(10);
            //a.SetRandom(20, 50);
            //Console.WriteLine(a);





            //int[] arr = { 1, 3, 6, 9, 8, 5, 3, 34, 56, 7, 90, 43 };
            //var aaa = arr.Where(a => a > 10);
            //Console.WriteLine(arr.Max());
            //foreach (var item in aaa)
            //{
            //    Console.WriteLine(  item);
            //}






            ///////////////////////////
            //                       //  
            /////// 04.04.2023  ///////
            //                       //
            ///////////////////////////



            //int[] arr = { 1, 3, 6, 9, 8, 5, 3, 34, 56, 7, 90, 43 };
            //var aaa = arr.Where(a => a > 10);
            //Console.WriteLine(arr.Max());
            //foreach (var item in aaa)
            //{
            //    Console.WriteLine(  item);
            //}


            //Student st1 = new Student
            //{
            //    FirstName = "",
            //    LastName = "",
            //    StudentCard = new StudentCard 
            //    { 
            //        Series = "AA", 
            //        Number = 99 
            //    } 
            //};

            //Student st2 = (Student)st1.Clone();

            //Console.WriteLine( st1);
            //Console.WriteLine( st2);

            //st2.StudentCard.Series = "FF";

            //Console.WriteLine(st1);
            //Console.WriteLine(st2);

            //Group pv221 = new Group();
            //foreach (Student item in pv221)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine();

            //pv221.Sort(Student.FromBirthDay);
            ////pv221.Sort(Student.FromStudentCard);

            //foreach (Student item in pv221)
            //{
            //    Console.WriteLine(item);
            //}


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

        private static void Teacher_ExamEvent1(DateTime dateTime)
        {
            throw new NotImplementedException();
        }
    }
}
