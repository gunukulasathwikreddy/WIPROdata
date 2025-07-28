using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Day7Part2Reflections
{
    internal class D_DeprecatedMethod
    {
        [Obsolete("Deprecated Method", false)]
        public static void TestMethod()
        {
            Console.WriteLine("Demo Method...");
        }
        static void Main()
        {

        }
    }
}
