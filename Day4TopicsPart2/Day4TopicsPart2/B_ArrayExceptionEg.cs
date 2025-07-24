using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4TopicsPart2
{
    internal class B_ArrayExceptionEg
    {
        static void Main()
        {
            int[] arr = new int[] { 10, 22 };
            try
            {
                arr[7] = 92;
            }
            catch(IndexOutOfRangeException e) 
            {
                Console.WriteLine("Index is Out of Range!!");
                // Console.WriteLine(e);
                // Console.WriteLine(e.Message);   
                // Console.WriteLine(e.StackTrace);
                // Console.WriteLine(e.ToString());
                // you can print these also
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
