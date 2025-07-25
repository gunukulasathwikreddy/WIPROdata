using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Day5Part1
{
    class OutPara
    {
        public void Method1(int eno, out string n,out double d)
        {
            n = string.Empty;
            d = 0;
            if(eno == 1)
            {
                n = "abc";
                d = 10.234;
            }
            if (eno == 2)
            {
                n = "def";
                d = 11.907;
            }
            if (eno == 3)
            {
                n = "ghi";
                d = 15.114;
            }
        }
    }

    internal class F_OutParametersEg
    {
        static void Main()
        {

            Console.Write("Enter Emp Number. The Choices are 1,2,3 : ");
            int EmpNo;
            
            string Name;
            double B;

            EmpNo = Convert.ToInt32(Console.ReadLine());

            OutPara outPara = new OutPara();
            outPara.Method1(EmpNo,out Name,out B);

            Console.WriteLine("EmpNo is : "+EmpNo);
            Console.WriteLine("Name is : " + Name);
            Console.WriteLine("Basic is : " + B);


        }
    }
}
    