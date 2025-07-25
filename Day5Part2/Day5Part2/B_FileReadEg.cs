using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Day5Part2
{
    internal class B_FileReadEg
    {
        static void Main()
        {
            FileStream fs = new FileStream(@"E:\WIPROSkillingPrograms\Day5Part1\Day5Part1\B_PropertiesExample.cs", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            while((line = sr.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            sr.Close();
            fs.Close();
        }
    }
}
