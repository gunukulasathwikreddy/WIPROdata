using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace ThreadingExamples
{
    internal class ThreadExample1
    {
        public static void OddShow()
        {
            for (int i = 1; i <= 20; i += 2)
            {
                Console.WriteLine("Odd  " + i);
                Thread.Sleep(1000);
            }
        }
        public static void EvenShow()
        {
            for (int i = 0; i <= 20; i += 2)
            {
                Console.WriteLine("Even  " + i);
                Thread.Sleep(1000);
            }
        }
        public static void Fact()
        {
            int f = 1;
            for (int i = 1; i <= 8; i++)
            {
                f = f * i;
                Console.WriteLine("Factorial Value  " + f);
                Thread.Sleep(1000);
            }
        }
        static void Main(string[] args)
        {
            ThreadStart ThStart1 = new ThreadStart(EvenShow);
            ThreadStart ThStart2 = new ThreadStart(OddShow);
            ThreadStart ThStart3 = new ThreadStart(Fact);

            Thread t1 = new Thread(ThStart1);
            Thread t2 = new Thread(ThStart2);
            Thread t3 = new Thread(ThStart3);

            t1.Start();
            t2.Start();
            t2.Join();
            t3.Start();
        }
    }
}
