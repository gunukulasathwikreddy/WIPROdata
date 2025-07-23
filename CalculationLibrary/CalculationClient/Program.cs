using CalculationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculationClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculation obj = new Calculation();
            Console.WriteLine("Enter two numbers :- ");
            int a, b;
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sum of given two numbers is : "+obj.Sum(a,b));
            Console.WriteLine("Subraction of given two numbers is : " + obj.Sub(a, b));
            Console.WriteLine("Multiplication of given two numbers is : " + obj.Mul(a, b));
        }
    }
}
