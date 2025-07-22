using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Topics
{
    internal class ObjRef
    {
        int x;
        static void Main()
        {
            ObjRef obj1 = new ObjRef();
            obj1.x = 12;
            ObjRef obj2 = obj1;
            obj2.x = 13;

            Console.WriteLine(obj1.x);

            Console.WriteLine(obj1.GetHashCode());
            Console.WriteLine(obj2.GetHashCode());

        }
    }
}
