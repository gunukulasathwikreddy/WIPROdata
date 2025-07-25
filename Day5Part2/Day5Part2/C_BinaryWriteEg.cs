using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Day5Part2
{
    internal class C_BinaryWriteEg
    {
        static void Main()
        {
            FileStream fs = new FileStream(@"E:\WIPROSkillingPrograms\FileWriteBinary.txt",FileMode.Create,FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(10);
            bw.Write("Sachin Tendulkar");
            bw.Write(189.615);
            bw.Write(true);
            bw.Flush();
            bw.Close();
            fs.Close();
            Console.WriteLine("File Write done Successfully.");
        }
    }
}
