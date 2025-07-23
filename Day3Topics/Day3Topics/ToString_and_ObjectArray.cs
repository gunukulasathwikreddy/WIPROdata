using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3Topics
{
    class Emp
    {
        int empno;
        string name;

        public Emp()
        {

        }

        public Emp(int empno, string name)
        {
            this.empno = empno;
            this.name = name;
        }

        public override string ToString()
        {
            return "empno = " + empno + " , name = " + name;
        }
    }
    internal class ToString_and_ObjectArray
    {
        static void Main(string[] args)
        {
            Emp[] emp = new Emp[]
            {
                new Emp(10,"Sachin Tendulkar"),
                new Emp(22,"Kane Williamson"),
                new Emp(15, "Bhuvneshwar Kumar")
            };

            foreach (Emp item in emp)
            {
                Console.WriteLine(item);
            }

        }
    }
}
