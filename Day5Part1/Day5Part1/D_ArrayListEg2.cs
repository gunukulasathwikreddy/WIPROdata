using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5Part1
{
    class Emp
    {
        public int Num { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return "Num : " + Num + " , Name = " + Name;
        }
    }
    internal class D_ArrayListEg2
    {
        static void Main()
        {
            Emp emp1 = new Emp();
            emp1.Num = 10;
            emp1.Name = "Sachin Tendulkar";

            Emp emp2 = new Emp();
            emp2.Num = 22;
            emp2.Name = "Kane Williamson";

            Emp emp3 = new Emp();
            emp3.Num = 15;
            emp3.Name = "Bhuvneshwar Kumar";

            ArrayList EmpArrayList = new ArrayList();
            EmpArrayList.Add(emp1);
            EmpArrayList.Add(emp2);
            EmpArrayList.Add(emp3);

            foreach (object empobj in EmpArrayList)
            {
                Emp emp = (Emp)empobj;
                Console.WriteLine(emp);
            }

        }
    }
}
