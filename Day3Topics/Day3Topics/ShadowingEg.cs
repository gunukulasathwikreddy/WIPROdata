using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Topics
{
    class BaseClass
    {
        public void Method1()
        {
            Console.WriteLine("Method From Base Class");
        }
    }

    class DerivedClass : BaseClass
    {
        public new void Method1()
        {
            Console.WriteLine("Method From Derived Class");
            // base.Method1(); this calls base class method if you remove comments.
        }

        public void CallBaseMethod()
        {
            Console.Write("Calling Base Class Method from Derived Class Using base keyword : ");
            base.Method1(); 
        }
    }
    internal class ShadowingEg
    {
        static void Main()
        {
            BaseClass baseClass = new BaseClass();
            baseClass.Method1();

            DerivedClass derivedClass = new DerivedClass();
            derivedClass.Method1();
            derivedClass.CallBaseMethod();
        }
    }
}
