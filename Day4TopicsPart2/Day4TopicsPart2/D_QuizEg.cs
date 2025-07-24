using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4TopicsPart2
{
    internal class D_QuizEg
    {
        static void Main()
        {
            int[] a = new int[] { 1, 2 };
            int x = 5, y = 0;
            try
            {
                a[2] = x / y;
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Array Size Small...");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Division By Zero Impossible...");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
