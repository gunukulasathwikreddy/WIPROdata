using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Day4TopicsPart2
{
    internal class E_ThrowEg
    {
        public void Show(int n)
        {
            if (n == 0)
            {
                throw new DivideByZeroException("Zero is not a positive number");
            }
            else if (n < 0)
            {
                throw new IndexOutOfRangeException("Negative Numbers not allowed");
            }
            else
            {
                Console.WriteLine("The number entered is : " + n);
            }
        }
        static void Main(string[] args)
        {
            int n;
            Console.Write("Enter a Positive Number : ");
            n = Convert.ToInt32(Console.ReadLine());
            E_ThrowEg obj = new E_ThrowEg();
            try
            {
                obj.Show(n);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
