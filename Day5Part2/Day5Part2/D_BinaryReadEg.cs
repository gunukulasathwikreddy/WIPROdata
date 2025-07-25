using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Day5Part2
{
    internal class D_BinaryReadEg
    {
        static void Main()
        {
            FileStream fs = new FileStream(@"E:\WIPROSkillingPrograms\FileWriteBinary.txt",FileMode.Open,FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            int x = br.ReadInt32();
            string y = br.ReadString();
            double d = br.ReadDouble();
            bool z = br.ReadBoolean();
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(d);
            Console.WriteLine(z);
            br.Close();
            fs.Close();
        }
    }
}
