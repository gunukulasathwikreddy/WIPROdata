using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableExamples
{
    internal class A_NullableEx1
    {
        static void Main(string[] args)
        {
            int? num = null;
            Console.WriteLine("num = "+num.GetValueOrDefault());
            num = 5;
            Console.WriteLine("num = " + num.GetValueOrDefault());
        }
    }
}
