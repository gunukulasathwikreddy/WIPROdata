using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7part3LamdaExp
{
    class Employ : IComparable<Employ>
    {
        public int Empno { get; set; }
        public string Name { get; set; }
        public double Basic { get; set; }

        public int CompareTo(Employ employ)
        {
            if (Empno >= employ.Empno)
            {
                return 1;
            }
            return -1;
        }

        public override string ToString()
        {
            return "Employ No " + Empno + " Employ Name " + Name + " Basic " + Basic;
        }
    }
    internal class A_LambdaExpEg1
    {
        static void Main(string[] args)
        {
            List<Employ> employList = new List<Employ>
            {
                new Employ{Empno=1,Name="Sachin Tendulkar",Basic=88323},
                new Employ{Empno=2,Name="Jasprit Bumrah",Basic=91133},
                new Employ{Empno=3,Name="Kane Williamson",Basic=80022},
                new Employ{Empno=4,Name="Bhuvneshwar Kumar",Basic=90321},
                new Employ{Empno=5,Name="Yashasvi Jaiswal",Basic=78822},
                new Employ{Empno=6,Name="Nitish Kumar Reddy",Basic=78823},
            };

            Console.WriteLine("Employ List  ");
            var result1 = employList.Select(x => x);
            foreach (var v in result1)
            {
                Console.WriteLine(v);
            }

            var result2 = employList.Select(x => new { x.Name, x.Basic });
            Console.WriteLine("Projected Fields are");
            foreach (var v in result2)
            {
                Console.WriteLine(v);
            }

            var result3 = employList.Where(x => x.Basic >= 90000);
            Console.WriteLine("Salary > 90000 records are");
            foreach (var v in result3)
            {
                Console.WriteLine(v);
            }

            var result4 = employList.Where(x => x.Name.StartsWith("S"));
            Console.WriteLine("Name Starts with 'S' :- ");
            foreach (var v in result4)
            {
                Console.WriteLine(v);
            }

        }
    }
}
