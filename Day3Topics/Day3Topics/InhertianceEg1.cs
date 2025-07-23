using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Topics
{
    class Animal
    {
        public void show()
        {
            Console.WriteLine("I am an Animal");
        }
    }

    class Dog : Animal
    {
        public void specify()
        {
            Console.WriteLine("I am a Dog");
        }
    }

    internal class InhertianceEg1
    {
        static void Main()
        {
            Dog d = new Dog();
            d.show();
            d.specify();
        }
    }
}
