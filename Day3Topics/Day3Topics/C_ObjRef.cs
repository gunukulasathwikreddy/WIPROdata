using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Topics
{
    internal class C_ObjRef
    {
        int num;
        static void Main()
        {
            C_ObjRef obj1 = new C_ObjRef();
            obj1.num = 15;
            C_ObjRef obj2 = obj1;
            obj2.num = 22;
            Console.WriteLine(obj1.num);
            Console.WriteLine("Hashcode of obj1 is "+obj1.GetHashCode());
            Console.WriteLine("Hashcode of obj2 is " + obj2.GetHashCode());

        }
    }
}
