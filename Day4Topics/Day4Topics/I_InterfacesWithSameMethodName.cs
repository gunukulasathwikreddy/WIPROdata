using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4Topics
{
    interface itf1
    {
        void Show();
    }
    interface itf2
    {
        void Show();
    }
    class cls : itf1,itf2
    {
        void itf1.Show()
        {
            Console.WriteLine("This is from interface 1 show() method");
        }

        void itf2.Show()
        {
            Console.WriteLine("This is from interface 2 show() method");
        }
    }
    internal class I_InterfacesWithSameMethodName
    {
        static void Main()
        {
            itf1 obj = new cls();
            obj.Show();

            itf2 obj2 = new cls();
            obj2.Show();

        }
    }
}
