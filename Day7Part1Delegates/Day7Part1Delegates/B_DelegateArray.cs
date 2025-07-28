using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7Part1Delegates
{
    internal class B_DelegateArray
    {
        public delegate void MyDelegate(int n);
        public static void Fact(int n)
        {
            if (n < 0)
            {
                Console.WriteLine("Factorial Value is not valid for negative numbers");
            }
            else if (n ==0 )
            {
                Console.WriteLine("Factorial Value of 0 is 1");
            }
            else
            {
                int f = 1;
                for (int i = 1; i <= n; i++)
                {
                    f = f * i;
                }
                Console.WriteLine("Factorial Value " + f);
            }
        }

        public static void PosNeg(int n)
        {
            if (n > 0)
            {
                Console.WriteLine("Positive Number...");
            }
            else if(n==0)
            {
                Console.WriteLine("0 is neither positive nor negative");
            }
            else
            {
                Console.WriteLine("Negative Number");
            }
        }

        public static void EvenOdd(int n)
        {
            if (n % 2 == 0)
            {
                Console.WriteLine("Even Number...");
            }
            else
            {
                Console.WriteLine("Odd Number...");
            }
        }

        static void Main()
        {
            Console.Write("Enter N Value  : ");
            int n = Convert.ToInt32(Console.ReadLine());

            
            MyDelegate[] arr =
            {
                new MyDelegate(PosNeg),
                new MyDelegate(EvenOdd),
                new MyDelegate(Fact)
            };

            foreach (MyDelegate m in arr)
            {
                m(n);
            }
        }
    }
}
