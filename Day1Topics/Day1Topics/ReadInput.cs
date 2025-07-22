using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Day1Topics
{
    internal class ReadInput
    {
        static void Main(string[] args)
        {
            string name;
            Console.WriteLine("Enter Name : ");
            name = Console.ReadLine();

            int rollno;
            Console.WriteLine("Enter Roll No : ");
            rollno = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Name is "+name+", roll no is "+rollno);
        }
    }
}
