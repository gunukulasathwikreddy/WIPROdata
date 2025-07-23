using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Topics
{
    internal class A_2darray
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rows and columns : ");
            int x = Convert.ToInt32(Console.ReadLine());
            int y = Convert.ToInt32(Console.ReadLine());

            int[,] arr = new int[x, y];

            for(int i = 0;i< arr.GetLength(0); i++)
            {
                for(int j = 0;j< arr.GetLength(1); j++)
                {
                    Console.WriteLine("Enter arr[{0},{1}] element : ",i,j);
                    arr[i,j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine("Printing the 2D Array in matrix form :- ");

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write(arr[i, j]+"  ");
                }
                Console.WriteLine();
            }
        }
    }
}
