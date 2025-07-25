using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Day5Part2
{
    internal class A_FileWriteEg
    {
        static void Main(string[] args)
        {
            FileStream fs = new FileStream(@"E:\WIPROSkillingPrograms\FileWrite.txt", FileMode.Create,FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("This is C# File Handling Program...");
            sw.WriteLine("WIPRO Pre Skilling Training");
            sw.WriteLine(".NET React");
            sw.Flush();
            sw.Close();
            fs.Close();
            Console.WriteLine("File Write Done Successfully.");
        }
    }
}
