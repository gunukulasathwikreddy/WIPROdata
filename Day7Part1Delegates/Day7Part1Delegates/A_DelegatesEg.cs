using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7Part1Delegates
{
    internal class A_DelegatesEg
    {
        public delegate void DelegatePrint();
        public delegate string DelegateStringCase(string name);
        public delegate void DelegateCal(int n, int m);

        public static void Show()
        {
            Console.WriteLine("This is Show Method");
        }

        public static string NameToUpper(string name)
        {
            return name.ToUpper();
        }

        public static void Add(int a, int b)
        {
            Console.WriteLine("The Result {0} + {1} is : {2}",a,b,(a+b));
        }

        public static void Mul(int a, int b)
        {
            Console.WriteLine("The Result {0} * {1} is : {2}", a, b, (a * b));
        }
        public static void Sub(int a, int b)
        {
            Console.WriteLine("The Result {0} - {1} is : {2}", a, b, (a - b));
        }

        static void Main(string[] args)
        {
            DelegatePrint obj1 = new DelegatePrint(Show);
            obj1();

            DelegateStringCase obj2 = new DelegateStringCase(NameToUpper);
            Console.WriteLine(obj2("Sachin Tendulkar"));

            DelegateCal obj3 = new DelegateCal(Add);
            obj3(7, 3);
            obj3 = new DelegateCal(Sub);
            obj3(7, 3);
            obj3 = new DelegateCal(Mul);
            obj3(7,3);
        }
    }
}
