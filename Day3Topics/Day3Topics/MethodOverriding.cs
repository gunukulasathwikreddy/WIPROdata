using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Topics
{
    class A
    {
        public void SampleMethod()
        {
            Console.WriteLine("Method From Base Class");
        }
    }

    class B : A
    {
        public void SampleMethod()
        {
            Console.WriteLine("Method From Derived Class");
           //  base.SampleMethod(); this calls base class method if you remove comments.
        }

        public void CallBaseMethod()
        {
            Console.Write("Calling Base Class Method from Derived Class Using base keyword : ");
            base.SampleMethod();
        }
    }
    internal class MethodOverriding
    {
        static void Main(string[] args)
        {
            A a = new A();
            a.SampleMethod();

            B b = new B();
            b.SampleMethod();
            b.CallBaseMethod();

        }
    }
}
