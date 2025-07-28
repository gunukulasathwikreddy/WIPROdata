using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7Part1Delegates
{
    internal class D_AnonymousDelegate
    {
        public delegate string AnonymousDelegate(string str);
        static void Main()
        {
            AnonymousDelegate obj = delegate (string str)
            {
                return "The given string is : " + str;
            };

            Console.WriteLine(obj("Sachin Tendulkar"));
        }
    }
}
