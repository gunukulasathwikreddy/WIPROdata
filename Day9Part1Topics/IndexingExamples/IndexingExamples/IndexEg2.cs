using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexingExamples
{
    class Emp
    {
        public int Empno { get; set; }
        public string Name { get; set; }
        public double Basic { get; set; }

        public override string ToString()
        {
            return "Employ No " + Empno + " Name " + Name + " Basic  " + Basic;
        }
    }
    internal class IndexEg2
    {
        Emp[] arr = new Emp[5];
        public Emp this[int id]
        {
            get
            {
                return arr[id];
            }
            set
            {
                arr[id] = value;
            }
        }

        static void Main()
        {
            IndexEg2 obj = new IndexEg2();
            obj[0] = new Emp { Empno = 10, Name = "Sachin Tendulkar", Basic = 82334 };
            obj[1] = new Emp { Empno = 22, Name = "Kane Williamson", Basic = 88222 };
            obj[2] = new Emp { Empno = 64, Name = "Yashasvi Jaiswal", Basic = 88231 };
            obj[3] = new Emp { Empno = 88, Name = "Nitish Kumar Reddy", Basic = 82144 };

            foreach (var v in obj.arr)
            {
                Console.WriteLine(v);
            }
        }
    }
}
