using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4Topics
{ 
    class Data
    {
        public void Show()
        {
            Console.WriteLine("Show Method from Class Data...");
        }

        public static void Display()
        {
            Console.WriteLine("Display Method from Class Data...");
        }
    }
    internal class B_StaticMethodPrgrm
    {
        static void Main()
        {
            Data.Display();
            new Data().Show();
        }
    }
}
