using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Topics
{
    internal class CountVowels
    {
        public void vowels(string str)
        {
            str = str.ToLower();
            char[] chr = str.ToCharArray();
            int count = 0;
            foreach(char i in chr)
            {
                if( i=='a' || i == 'e' || i == 'i' || i == 'o' || i == 'u' )
                {
                    count++;
                }
            }
            Console.WriteLine("The total Vowels in your given sentence is : "+count);

        }
        static void Main()
        {
            Console.WriteLine("Enter your sentence : ");
            string str = Console.ReadLine();
            CountVowels obj1 = new CountVowels();
            obj1.vowels(str);

        }
    }
}
