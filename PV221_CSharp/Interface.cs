using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV221_CSharp
{
    internal interface IWorker
    {
        void Work();
        bool IsWork { get; set; }
        
    }


    internal interface IManager
    {
        void CreateReport();

        void Control();

    }


    class Manager : Employee, IManager
    {
        public void Control()
        {
            Console.WriteLine("I`m control working");
        }

        public void CreateReport()
        {
            Console.WriteLine("I`m creating raport");
        }

        public override void Dancing()
        {
            throw new NotImplementedException();
        }

    }

    class Brigadir : Employee, IWorker
    {
        public bool IsWork { get; set; } = true;

        public override void Dancing()
        {
            throw new NotImplementedException();
        }

        public void Work()
        {
            Console.WriteLine("I`m building house");
        }
    }


    class Builder : Employee, IWorker
    {
        public bool IsWork { get; set; } = true;

        public override void Dancing()
        {
            throw new NotImplementedException();
        }

        public void Work()
        {
            Console.WriteLine("I`m building house");
        }
    }





    public interface IIndex
    {
        string this[int index] { get; set; }    

    }

    class Collection : IIndex
    {
        string[] names = { "Olga", "Ivan", "Maria", "Yuri" };

        public string this[int index] 
        {
            get { return names[index]; }
            set { names[index] = value; }  
        }
    }



    interface IA
    {
        void Show();
    }

    interface IB
    {
        void Show();
    }

    interface IC
    {
        void Show();
    }

    class Inter : IA, IB, IC
    {
        public void Show()
        {
            Console.WriteLine("Show");
        }

        void IA.Show()
        {
            Console.WriteLine("IA Show");
        }

        void IB.Show()
        {
            Console.WriteLine("IB Show");
        }

        //void IC.Show()
        //{
        //    Console.WriteLine("IC Show");
        //}
    }


}
