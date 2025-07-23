using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Topics
{
    internal class D_StringDemo
    {
        static void Main()
        {
            string s1 = "cricket player", s2 = "tennis player", s3 = "software engineer", s4 = "cricket player";
            Console.WriteLine(s1.GetHashCode());
            Console.WriteLine(s2.GetHashCode());
            Console.WriteLine(s3.GetHashCode());
            Console.WriteLine(s4.GetHashCode());
        }
    }
}
