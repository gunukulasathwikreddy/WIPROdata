using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4TopicsPart2
{
    internal class A_DivisionExceptionEg
    {
        static void Main(string[] args)
        {
            int x, y, q;
            Console.WriteLine("Enter two Numbers :-");
            try
            {
                x = Convert.ToInt32(Console.ReadLine());
                y = Convert.ToInt32(Console.ReadLine());
                q = x / y;
                Console.WriteLine("The Result {0}/{1} is : {2}  ",x,y,q);
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Number is Too Big...");
            }
            catch (FormatException e)
            {
                //Console.WriteLine(e.Message);
                Console.WriteLine("Input is in not correct format...");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Division By Zero Impossible...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("This is a try catch finally program.");
            }
        }
    }
}
