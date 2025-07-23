using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Topics
{
    internal class B_JaggedArray
    {
        static void Main()
        {
            Console.Write("Enter number of jagged arrays : ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] JaggedArr = new int[n][];

            for(int i = 0;i<n;i++)
            {
                Console.WriteLine("Enter Size of {0} array : ",(i+1));
                int x = Convert.ToInt32(Console.ReadLine());
                int[] temp = new int[x];
                Console.WriteLine("Enter Array Elements :- ");
                for(int  j = 0;j<x;j++)
                {
                    temp[j] = Convert.ToInt32(Console.ReadLine());
                }
                JaggedArr[i] = temp;
            }

            Console.WriteLine("Printing Jagged Array :- ");
            for (int i = 0; i<JaggedArr.Length;i++)
            {
                Console.Write("JaggedArr[{0}] : ", i);
                for (int j = 0; j < JaggedArr[i].Length;j++)
                {
                    Console.Write(JaggedArr[i][j] +" ");
                }
                Console.WriteLine();
            }

        }
    }
}
