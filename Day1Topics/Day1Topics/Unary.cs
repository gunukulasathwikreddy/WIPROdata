using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Topics
{
    internal class Unary
    {
        static void Main(string[] args)
        {
            int x = 10;
            Console.WriteLine("the value of x is : " + x);
            int y = x++ + ++x;
            Console.WriteLine("the value of y i.e. x++ + ++x is : " + y);

            int a = 12;
            Console.WriteLine("the value of a is : " + a);
            Console.WriteLine("a++ + ++a + ++a + a++ is : " + (a++ + ++a + ++a + a++));


            int p = 12;
            Console.WriteLine("the value of p is : " + p);
            Console.WriteLine("p++ + p-- + --p + ++p + p++ + --p is : " + (p++ + p-- + --p + ++p + p++ + --p));
        }
    }
}
