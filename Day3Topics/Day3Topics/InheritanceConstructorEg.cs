using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Topics
{
    class Base
    { 
        public Base() 
        {
            Console.WriteLine("This is From Base class Constructor Base()");
        }
    }

    class Derived : Base
    {
        public Derived()
        {
            Console.WriteLine("This is From Derived class Constructor Derived()");
        }
    }

    internal class InheritanceConstructorEg
    {
        static void Main()
        {
            Derived obj = new Derived();
        }
    }
}
