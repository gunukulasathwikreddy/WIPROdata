using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4Topics
{
    abstract class Animal
    {
        public void Show()
        {
            Console.WriteLine("I am an Animal");
        }
        public abstract void Name();
        public abstract void Description();
    }

    class Cow : Animal
    {
        public override void Name()
        {
            Console.WriteLine("Name is Cow...");
        }

        public override void Description()
        {
            Console.WriteLine("It is Mammal Category...");
        }
    }

    class Lion : Animal
    {
        public override void Name()
        {
            Console.WriteLine("Name is Lion...");
        }

        public override void Description()
        {
            Console.WriteLine("It is Wild Animal...");
        }

    }

    internal class E_AbsractClassEg
    {
        static void Main()
        {
            Animal[] arr = new Animal[]
            {
                new Cow(),
                new Lion()
            };

            foreach (Animal obj in arr)
            {
                obj.Show();
                obj.Name();
                obj.Description();
            }
        }
    }
}
