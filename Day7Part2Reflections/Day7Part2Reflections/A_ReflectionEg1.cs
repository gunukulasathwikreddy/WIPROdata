using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Day7Part2Reflections
{
    class Test
    {
        public int a;
        public void ShowMethod()
        {
            Console.WriteLine("This is Show Method");
        }
    }
    internal class A_ReflectionEg1
    {
        static void Main(string[] args)
        {
            Type typeObj = typeof(Test);
            Console.WriteLine("Methods Avaialble in Test Class Are :- ");
            foreach (MethodInfo mi in typeObj.GetMethods())
            {
                Console.WriteLine(mi.Name);
            }
            Console.WriteLine("Variables available in the class are :- ");
            foreach (FieldInfo fi in typeObj.GetFields())
            {
                Console.WriteLine(fi.Name);
            }
        }
    }
}
