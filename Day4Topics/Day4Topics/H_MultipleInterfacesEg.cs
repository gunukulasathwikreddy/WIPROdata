using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4Topics
{
    interface A
    {
        void MethodA();
    }
    interface B
    {
        void MethodB();
    }
    class C : A, B
    {
        public void MethodA()
        {
            Console.WriteLine("This is MethodA");
        }

        public void MethodB()
        {
            Console.WriteLine("This is MethodB");
        }
    }

    internal class H_MultipleInterfacesEg
    {
        static void Main()
        {
            C c = new C();
            c.MethodA();
            c.MethodB();
        }
    }
}
