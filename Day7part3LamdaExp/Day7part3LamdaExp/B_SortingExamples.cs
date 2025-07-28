using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7part3LamdaExp
{
    class NameComparer : Comparer<Employ>
    {
        public override int Compare(Employ x, Employ y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    class BasicComparer : Comparer<Employ>
    {
        public override int Compare(Employ x, Employ y)
        {
            if (x.Basic >= y.Basic)
            {
                return 1;
            }
            return -1;
        }
    }
    internal class B_SortingExamples
    {
        static void Main()
        {
            List<Employ> employList = new List<Employ>
            {
                new Employ{Empno=10,Name="Sachin Tendulkar",Basic=88323},
                new Employ{Empno=93,Name="Jasprit Bumrah",Basic=91133},
                new Employ{Empno=22,Name="Kane Williamson",Basic=80022},
                new Employ{Empno=15,Name="Bhuvneshwar Kumar",Basic=90321},
                new Employ{Empno=64,Name="Yashasvi Jaiswal",Basic=78822},
                new Employ{Empno=88,Name="Nitish Kumar Reddy",Basic=78823},
            };

            employList.Sort();
            Console.WriteLine("Sorted Data (default w.r.t. Empno)  ");
            var result1 = employList.Select(x => x);
            foreach (var v in result1)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine("Sort by Name-wise  ");
            employList.Sort(new NameComparer());
            var result2 = employList.Select(x => x);
            foreach (var v in result2)
            {
                Console.WriteLine(v);
            }

            Console.WriteLine("Sort By Basic-Wise ");
            employList.Sort(new BasicComparer());
            foreach (var v in employList)
            {
                Console.WriteLine(v);
            }


        }
    }
}
