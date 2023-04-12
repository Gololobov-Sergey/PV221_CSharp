using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV221_CSharp
{
    class StudentCard : IComparable<StudentCard>, ICloneable
    {
        public int Number { get; set; }

        public string Series { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(StudentCard obj)
        {
            if (Series == obj.Series)
            {
                return Number.CompareTo(obj.Number);
            }
            else
            {
                return Series.CompareTo(obj.Series);
            }
        }

        public override string ToString()
        {
            return $"{Series} {Number}";
        }
    }


    internal class Student : IComparable<Student>, ICloneable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDay { get; set; }

        public StudentCard StudentCard { get; set; }

        public static IComparer<Student> FromBirthDay { get { return new DateComparer(); } }

        public static IComparer<Student> FromStudentCard { get { return new StudentCardComparer(); } }

        public int CompareTo(Student obj)
        {
            return LastName.CompareTo(obj.LastName);
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

        public override int GetHashCode()
        {
            return $"{LastName}".GetHashCode();
        }

    }


    class Group /*: IEnumerable<Student>*/
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

        public IEnumerator<Student> GetEnumerator()
        {
            for (int i = 0; i < students.Length; i++)
            {
               yield return students[i];
            }
        }


        public void Sort(IComparer<Student> comparer)
        {
            Array.Sort(students, comparer);
        }

        public void Sort()
        {
            Array.Sort(students);
        }

        //public IEnumerator<Student> GetEnumerator()
        //{
        //    return ((IEnumerable<Student>)students).GetEnumerator();
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return students.GetEnumerator();
        //}
    }

    class DateComparer : IComparer<Student>, IComparer<Point>
    {
        public int Compare(Student x, Student y)
        {
            return DateTime.Compare(x.BirthDay, y.BirthDay);
        }

        public int Compare(Point x, Point y)
        {
            throw new NotImplementedException();
        }
    }

    class StudentCardComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.StudentCard.CompareTo(y.StudentCard);
        }
    }

}
