using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1Topics
{
    internal class QuizQuestions
    {
        static void Main()
        {
            Console.WriteLine("5" + 3 + 8); //538
            Console.WriteLine("5" + (3 + 8)); // 511
            Console.WriteLine("5 + 3" + 8); // 5+38

            char ch = 'A';
            ch++;
            Console.WriteLine(ch);

            char c = 'A';
            int a = c;
            Console.WriteLine(a);

        }
    }
}
