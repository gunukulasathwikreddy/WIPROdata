using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace Day5Part1
{
    internal class E_CollectionsStackEg
    {
        static void Main()
        {
            Stack stackobj = new Stack();
            stackobj.Push(10);
            stackobj.Push(22);
            stackobj.Push(15);
            stackobj.Push(63);

            Console.WriteLine("Stack Data :- ");
            foreach (object o in stackobj)
            {
                Console.WriteLine(o);
            }

            stackobj.Pop();
            Console.WriteLine("Pop element.");
            Console.WriteLine("Stack Data :- ");
            foreach (object o in stackobj)
            {
                Console.WriteLine(o);
            }
        }
    }
}
