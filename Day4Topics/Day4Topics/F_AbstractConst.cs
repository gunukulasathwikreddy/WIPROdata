using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4Topics
{
    abstract class Emp
    {
        private int Empno;
        private string Name;

        public Emp(int Empno,string Name) 
        { 
            this.Empno = Empno;
            this.Name = Name;
        }

        public override string ToString()
        {
            return "empno = " + this.Empno + " , Name = " + this.Name;
        }

    }

    class Emp1 : Emp
    {
        public Emp1(int Empno,string Name) : base (Empno, Name) 
        {
            
        }
    }

    class Emp2 : Emp
    {
        public Emp2(int Empno, string Name) : base(Empno, Name)
        {

        }
    }

    internal class F_AbstractConst
    {
        static void Main()
        {
            Emp[] arr = new Emp[]
            {
                new Emp1(10,"Sachin Tendulkar"),
                new Emp2(22,"Kane Williamson")
            };

            foreach(Emp item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
