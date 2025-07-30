using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexingExamples
{
    class Demo
    {
        public string[] name = new string[5];

        public string this[int i]
        {
            get
            {
                return name[i];
            }
            set
            {
                name[i] = value;
            }
        }
    }
    internal class IndexEg1
    {
        static void Main(string[] args)
        {
            Demo demo = new Demo();
            demo[0] = "Sachin Tendulkar";
            demo[1] = "Kane Williamson";
            demo[2] = "Bhuvneshwar Kumar";
            demo[3] = "Yashasvi Jaiswal";
            demo[4] = "Nitish Kumar Reddy";
            Console.WriteLine("Data is :- ");
            foreach (var v in demo.name)
            {
                Console.WriteLine(v);

            }
        }
    }
}
