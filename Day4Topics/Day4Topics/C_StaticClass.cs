using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4Topics
{
    static class Demo
    {
        public static void Show()
        {
            Console.WriteLine("Show Method from Demo Class...");
        }

        public static string Trainer()
        {
            return "This is dot net programming";
        }
    }
    internal class C_StaticClass
    {
        static void Main()
        {
            Demo.Show();
            Console.WriteLine(Demo.Trainer());
        }
    }
}
