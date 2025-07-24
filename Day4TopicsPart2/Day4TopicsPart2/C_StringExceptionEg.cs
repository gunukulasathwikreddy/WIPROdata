using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4TopicsPart2
{
    internal class C_StringExceptionEg
    {
        static void Main()
        {
            string str = "Kane Williamson";
            try
            {
                Console.WriteLine(str.Substring(1, 89));
            }
            catch (ArgumentOutOfRangeException e)
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
