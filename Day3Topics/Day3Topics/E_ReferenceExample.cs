using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Topics
{
    internal class E_ReferenceExample
    {
        public void Inc(ref int x)
        {
            x++;
        }
        static void Main()
        {
            int x = 10;
            E_ReferenceExample obj = new E_ReferenceExample();
            obj.Inc(ref x);
            Console.WriteLine("The value of x after obj.Inc(ref x) is : " + x);
        }
    }
}
