using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Day3Topics
{

    
    internal class F_FactorialRefEg
    {
        public void factorial(int n, ref int f)
        {

            for (int i = 1; i <= n; i++)
            {
                f = f * i;
            }
        }
        static void Main()
        {
            int n, f = 1;
            Console.Write("Enter N value : ");
            n = Convert.ToInt32(Console.ReadLine());
            F_FactorialRefEg obj = new F_FactorialRefEg(); 
            obj.factorial(n, ref f);
            Console.WriteLine("Factorial Value  " + f);
        }

    }
}
