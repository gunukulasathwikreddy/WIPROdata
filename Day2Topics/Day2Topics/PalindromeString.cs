using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Topics
{
    internal class PalindromeString
    {
        public bool IsPalindrome(string check)
        {
            char[] chars = check.ToCharArray();
            string rev = "";
            for(int i = chars.Length-1;i>=0;i--)
            {
                rev += chars[i];
            }
            if (rev.Equals(check))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void print_Palindromes(string palindromes)
        {
            string[] data = palindromes.Split(' ');
            foreach (string s in data)
            {
                if(IsPalindrome(s)==true)
                {
                    Console.WriteLine(s);
                }
            }
            Console.WriteLine("These are the palindromes in given string");
        }
        static void Main()
        {
            Console.WriteLine("Enter a string with palindromes : ");
            string str = Console.ReadLine();
            PalindromeString pal = new PalindromeString();
            pal.print_Palindromes(str);
        }
    }
}
