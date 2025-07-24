using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4Topics
{
    class Cal
    {

        public void Sum(int x,int y)
        {
            Console.WriteLine("The sum {0} + {1} is : {2}",x,y,(x+y));
        }

        public void Sub(int x, int y)
        {
            Console.WriteLine("The sub {0} - {1} is : {2}", x, y, (x - y));
        }
    }

    static class CalExtension
    {
        public static void Mul(this Cal c, int x, int y)
        {
            Console.WriteLine("The mul {0} * {1} is : {2}", x, y, (x * y));
        }
        public static void Div(this Cal c, int x, int y)
        {
            if(y!=0)
            {
                Console.WriteLine("The div {0} / {1} is : {2}", x, y, (x / y));
            }
            else
            {
                Console.WriteLine("Div by 0 is not possible");
            }
        }
    }

    internal class D_ExtensionEg
    {
        static void Main()
        {
            Cal c = new Cal();
            c.Sum(12, 6);
            c.Sub(12, 6);
            c.Mul(12, 6);
            c.Div(12, 6);
        }
    }
}
