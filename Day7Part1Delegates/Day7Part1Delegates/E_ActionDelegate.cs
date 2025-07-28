using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7Part1Delegates
{
    internal class E_ActionDelegate
    {
        public static void Add(int a,int b)
        {
            Console.WriteLine("The Result {0} + {1} is :{2} ",a,b,(a+b));
        }

        public static void Sub(int a, int b)
        {
            Console.WriteLine("The Result {0} - {1} is :{2} ", a, b, (a - b));
        }

        public static void Mul(int a, int b)
        {
            Console.WriteLine("The Result {0} * {1} is :{2} ", a, b, (a * b));
        }

        static void Main()
        {
            Action<int, int> obj = Add;
            obj += Sub;
            obj += Mul;

            Console.WriteLine("Enter Two Numbers :- ");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());

            obj(a, b);
        }

    }
}
