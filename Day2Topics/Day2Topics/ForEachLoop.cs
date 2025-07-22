using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Topics
{
    internal class ForEachLoop
    {
        public void ForEach()
        {
            int[] arr = new int[] { 10, 20, 30, 40, 51 };
            foreach(int i in arr)
            {
                Console.WriteLine(i);
            }

        }

        public void Forloop()
        {
            int[] a = new int[4];
            Console.WriteLine("Enter your four array numbers : ");
            a[0] = Convert.ToInt32(Console.ReadLine());
            a[1] = Convert.ToInt32(Console.ReadLine());
            a[2] = Convert.ToInt32(Console.ReadLine());
            a[3] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Array elements are : ");
            for(int i=0;i<a.Length;i++)
            {
                Console.WriteLine(a[i]);
            }
        }

        static void Main()
        {
            ForEachLoop forEachLoop = new ForEachLoop();
            forEachLoop.ForEach();
            forEachLoop.Forloop();
        }
    }
}
