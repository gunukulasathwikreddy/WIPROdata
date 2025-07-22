using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Topics
{
    internal class SpiltString
    {
        public void string_split(string str)
        {
            string[] split = str.Split(' ');
            for (int i = 0; i < split.Length; i++)
            {
                Console.WriteLine("split["+i+"] is "+split[i]);
            }

        }
        static void Main()
        {
           SpiltString obj1 = new SpiltString();
           Console.WriteLine("Enter Your String : ");
           string str = Console.ReadLine();
           obj1.string_split(str);
        }
    }
}
