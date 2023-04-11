using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV221_CSharp
{
     class StudentCard : IComparable, ICloneable
    {
        public int Number { get; set; }

        public string Series { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            StudentCard sc = obj as StudentCard;
            if (Series == sc.Series)
            {
                return Number.CompareTo(sc.Number);
            }
            else
            {
                return Series.CompareTo(sc.Series);
            }
        }

        public override string ToString()
        {
            return $"{Series} {Number}";
        }
    }


    internal class Student : IComparable, ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public StudentCard StudentCard { get; set; }


        public static IComparer FromBirthDay { get { return new DateComparer(); } }

        public static IComparer FromStudentCard { get { return new StudentCardComparer(); } }

        public int CompareTo(object obj)
        {
            return LastName.CompareTo((obj as Student).LastName);
        }

        public override string ToString()
        {
            return $"{LastName?.PadRight(15)} {FirstName?.PadRight(10)} {BirthDay.ToShortDateString()} {StudentCard}";
        }

        public object Clone()
        {
            Student st = this.MemberwiseClone() as Student;
            st.StudentCard = this.StudentCard.Clone() as StudentCard;
            return st;
        }

        //public override int GetHashCode()
        //{
        //    return base.GetHashCode();
        //}

    }


    class Group : IEnumerable
    {
        Student[] students =
        {
            new Student()
            {
                LastName = "Osipov",
                FirstName = "Oleg",
                BirthDay = new DateTime(2000, 12, 15),
                StudentCard = new StudentCard()
                {
                    Series = "AB",
                    Number = 123456
                }
            },
            new Student()
            {
                LastName = "Petrova",
                FirstName = "Maria",
                BirthDay = new DateTime(2002, 04, 20),
                StudentCard = new StudentCard()
                {
                    Series = "AB",
                    Number = 129956
                }
            },
            new Student()
            {
                LastName = "Fedorov",
                FirstName = "Petro",
                BirthDay = new DateTime(1999, 01, 10),
                StudentCard = new StudentCard()
                {
                    Series = "AC",
                    Number = 123456
                }
            },
            new Student()
            {
                LastName = "Abrampva",
                FirstName = "Olga",
                BirthDay = new DateTime(2000, 12, 14),
                StudentCard = new StudentCard()
                {
                    Series = "AA",
                    Number = 123451
                }
            }
        };


        public void Sort(IComparer comparer)
        {
            Array.Sort(students, comparer);
        }

        public void Sort()
        {
            Array.Sort(students);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return students.GetEnumerator();
        }
    }

    class DateComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if(x is Student && y is Student)
            {
                return DateTime.Compare((x as Student).BirthDay, (y as Student).BirthDay);  
            }
            throw new NotImplementedException();
        }
    }

    class StudentCardComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Student && y is Student)
            {
                return (x as Student).StudentCard.CompareTo((y as Student).StudentCard);
            }
            throw new NotImplementedException();
        }
    }

}
