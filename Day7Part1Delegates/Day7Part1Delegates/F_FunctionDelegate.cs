using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7Part1Delegates
{
    internal class F_FunctionDelegate
    {
        public static int Compare(string s1, string s2)
        {
            return s1.CompareTo(s2);
        }

        public static bool PosNum(int a)
        {
            if (a <= 0)
            {
                return false;
            }
            return true;
        }

        public static int Add(int a, int b) 
        { 
            return a + b; 
        }

        static void Main()
        {
            Console.WriteLine("Enter two Strings :-");
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();
            Func<string,string,int> obj1 = Compare;
            Console.WriteLine(obj1(str1, str2));

            Console.WriteLine("Enter two Numbers :-");
            int n1 = Convert.ToInt32(Console.ReadLine());
            int n2 = Convert.ToInt32(Console.ReadLine());
            Func<int,int,int> obj2 = Add;
            Console.WriteLine("The Addition is : "+obj2(n1, n2));

            Console.Write("Enter a number to check if it is positive : ");
            int n = Convert.ToInt32(Console.ReadLine());
            Func<int,bool> obj3 = PosNum;
            Console.WriteLine(obj3(n));
        }

    }
}
