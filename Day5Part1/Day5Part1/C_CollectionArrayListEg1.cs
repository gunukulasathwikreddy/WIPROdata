using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5Part1
{
    internal class C_CollectionArrayListEg1
    {
        static void Main()
        {
            ArrayList arrayListStrObj = new ArrayList();
            arrayListStrObj.Add("Sachin Tendulkar");
            arrayListStrObj.Add("Kane Williamson");
            arrayListStrObj.Add("Bhuvneshwar Kumar");

            Console.WriteLine("ArrayList Elements are :- ");
            foreach (object obj in arrayListStrObj)
            {
                Console.WriteLine(obj);
            }

            arrayListStrObj.Insert(2, "Jasprit Bumrah");
            Console.WriteLine("ArrayList Elements are :- ");
            foreach (object obj in arrayListStrObj)
            {
                Console.WriteLine(obj);
            }


            arrayListStrObj.Remove("Bhuvneshwar Kumar");
            Console.WriteLine("ArrayList Elements are :- ");
            foreach (object obj in arrayListStrObj)
            {
                Console.WriteLine(obj);
            }

            arrayListStrObj.RemoveAt(1);
            Console.WriteLine("ArrayList Elements are :- ");
            foreach (object obj in arrayListStrObj)
            {
                Console.WriteLine(obj);
            }
        }
    }
}
