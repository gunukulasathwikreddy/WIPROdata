using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4Topics
{
    interface Cricket
    {
        void Name();
        void Role();

    }

    class Sachin : Cricket
    {
        public void Name()
        {
            Console.WriteLine("Name is Sachin");
        }

        public void Role()
        {
            Console.WriteLine("Role is Batsman");
        }
    }

    class Jasprit : Cricket
    {
        public void Name()
        {
            Console.WriteLine("Name is Jasprit");
        }

        public void Role()
        {
            Console.WriteLine("Role is Bowler");
        }
    }

    internal class G_InterfaceEg
    {
        static void Main()
        {
            Cricket[] arr = new Cricket[]
            {
                new Sachin(),
                new Jasprit()
            };

            foreach (var item in arr)
            {
                Console.WriteLine("-------------------------------------------------");
                item.Name();
                item.Role();
            }
        }
    }
}
