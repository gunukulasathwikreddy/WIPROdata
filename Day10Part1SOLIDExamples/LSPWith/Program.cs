using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPWith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Details[] arr = new Details[]
            {
                new Sachin(),
                new Kane(),
                new Bhuvi()
            };

            foreach (var v in arr)
            {
                v.ShowInfo();
            }
        }
    }
}
