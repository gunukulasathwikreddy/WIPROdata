using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5Part1
{
    class ReadOnlyEg
    {
        public int Accno { get; } = 10001926;
        public string IFSC { get; } = "IFSC1234";
    }
    class WriteOnlyEg
    {
        int id;
        string name;

        public int IdNum { set { id = value; } }
        public string Name { set { name = value; } }

        public override string ToString()
        {
            return "From WriteOnlyEg : " + "IdNum = " + id + " , Name = "+name;
        }
    }
    class AutoImplentEg
    {
        public int Empno { get; set; }
        public string EmpName { get; set; }
    }

    internal class B_PropertiesExample
    {
        static void Main(string[] args)
        {
            ReadOnlyEg readOnlyEg = new ReadOnlyEg();
            Console.WriteLine("ReadOnlyEg Accno = "+readOnlyEg.Accno);
            Console.WriteLine("ReadOnlyEg IFSC = "+readOnlyEg.IFSC);

            Console.WriteLine("_________________________________________________________");

            WriteOnlyEg writeOnlyEg = new WriteOnlyEg();
            writeOnlyEg.IdNum = 1;
            writeOnlyEg.Name = "Test";
            Console.WriteLine(writeOnlyEg);

            Console.WriteLine("_________________________________________________________");

            AutoImplentEg autoImplentEg = new AutoImplentEg();
            autoImplentEg.Empno = 1234;
            autoImplentEg.EmpName = "ABC";
            Console.WriteLine("This is from AutoImplementEg");
            Console.WriteLine("Empno = " + autoImplentEg.Empno);
            Console.WriteLine("EmpName = " + autoImplentEg.EmpName);



        }
    }
}
