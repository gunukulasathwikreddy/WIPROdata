using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LSPWithout
{
    internal class Second : First
    {
        public new void ShowInfo()
        {
            Console.WriteLine("Hello. I am from Second Method");
        }
    }
}
