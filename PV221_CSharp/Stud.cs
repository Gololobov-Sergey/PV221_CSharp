using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV221_CSharp
{
    enum Course
    {
        Programm, Admin, Design, SQL
    }

    internal class Stud : IIndex
    {
        int[][] marks;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Group { get; set; }

        public string this[int index] 
        {
            get { return this[(Course)index]; } 
            set => throw new NotImplementedException(); 
        }

        public Stud()
        {
            marks = new int[Enum.GetValues(typeof(Course)).Length][];
            for (int i = 0; i < marks.Length; i++)
            {
                marks[i] = new int[0];
            }
        }


        public void Info()
        {
            Console.WriteLine($"{LastName} {FirstName}, Group: {Group}");

            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write($"{Enum.GetName(typeof(Course), i)}: ");

                Console.WriteLine(string.Join(", ", marks[i]));
            }
        }

        public void AddMark(Course course, int mark)
        {
            int index = (int)course;
            int[] newMark = new int[marks[index].Length + 1];
            for (int i = 0; i < marks[index].Length; i++)
            {
                newMark[i] = marks[index][i];
            }
            newMark[newMark.Length - 1] = mark;
            marks[index] = newMark;
        }

        public int GetLastMark(Course course)
        {
            return marks[(int)course].Length == 0 ? 0 : marks[(int)course][marks[(int)course].Length - 1];
        }

        internal float GetAvarageCourse(Course course)
        {
            float sum = 0;
            foreach (var item in marks[(int)course])
            {
                sum += item;
            }
            return sum / marks[(int)course].Length;
        }

        public string this[Course course]
        {
            get
            {
                return $"{course}: " + string.Join(", ", marks[(int)course]);
            }

            set
            {
                int mark;
                if(Int32.TryParse(value, out mark))
                {
                    AddMark(course, mark);
                }
            }
        }
    }
}
