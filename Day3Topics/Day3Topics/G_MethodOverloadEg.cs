using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Topics
{
    internal class G_MethodOverloadEg
    {
        public int AddMethod()
        {
            Console.WriteLine("Adding 0");
            return 0;
        }
        public int AddMethod(int x)
        {
            Console.WriteLine("Adding 10 to the given number");
            return x + 10;
        }
        public int AddMethod(int x,int y)
        {
            Console.WriteLine("Adding given two numbers x + y");
            return x + y;
        }

        public void show()
        {
            Console.WriteLine("Showing no arguments");
        }

        public void show(int x)
        {
            Console.WriteLine("Showing int data "+x);
        }

        public void show(double x)
        {
            Console.WriteLine("Showing double data " + x);
        }

        public void show(int x,double y)
        {
            Console.WriteLine("Showing int data {0} and double data {1}",x,y);
        }

        static void Main()
        {
            G_MethodOverloadEg obj = new G_MethodOverloadEg();
            Console.WriteLine(obj.AddMethod());
            Console.WriteLine(obj.AddMethod(7));
            Console.WriteLine(obj.AddMethod(7,15));
            obj.show();
            obj.show(7);
            obj.show(10.7);
            obj.show(7,10.7);
        }

    }
}
