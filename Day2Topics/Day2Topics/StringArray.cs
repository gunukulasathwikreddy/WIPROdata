using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Topics
{
    internal class StringArray
    {
        public void stringarrayshow()
        {
            string[] strarray = new string[] { "Hello", "World", "Dot Net", "Programming C#" };

            foreach (string str in strarray)
            {
                Console.WriteLine(str);
            }
        }
        static void Main()
        {
            StringArray stringArray = new StringArray();
            stringArray.stringarrayshow();
        }
    }
}
