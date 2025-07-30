using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NullableExamples
{
    internal class C_NullableCoalescingEg
    {
       static void Main(string[] args)
        {
            string s1 = null;
            string s2 = "Sachin Tendulkar";
            string s3 = "Kane Williamson";

            string s4 = s1 ?? s2;
            Console.WriteLine(s4);
            s4 = s3 ?? s2;
            Console.WriteLine(s4);
        }

    }
}
