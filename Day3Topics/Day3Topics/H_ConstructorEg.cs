using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Topics
{
    internal class H_ConstructorEg
    {
        int a, b;
        
        static H_ConstructorEg()
        {
            Console.WriteLine("This is from static Constructor");
        }

        public H_ConstructorEg()
        {
            a = 0;
            b = 0;
        }

        public H_ConstructorEg(int a)
        {
            this.a = a;
        }

        public H_ConstructorEg(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public void printvalues()
        {
            Console.WriteLine("value of a is : {0} , value of b is : {1}",a,b);
        }

        static void Main()
        {
            H_ConstructorEg obj1 = new H_ConstructorEg();
            H_ConstructorEg obj2 = new H_ConstructorEg(10);
            H_ConstructorEg obj3 = new H_ConstructorEg(10,20);

            obj1.printvalues();
            obj2.printvalues();
            obj3.printvalues();

        }

    }
}
