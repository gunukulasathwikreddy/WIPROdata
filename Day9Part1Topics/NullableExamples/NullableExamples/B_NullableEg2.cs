using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullableExamples
{
    class Employ
    {
        public int Empno { get; set; }
        public string Name { get; set; }
        public double Basic { get; set; }
        public int? LeaveDays { get; set; }

        public Nullable<int> LeaveStatus { get; set; }
    }
    internal class B_NullableEg2
    {
        static void Main()
        {
            Employ employ1 = new Employ();
            employ1.Empno = 10;
            employ1.Name = "Sachin Tendulkar";
            employ1.Basic = 88323;

            Employ employ2 = new Employ();
            employ2.Empno = 22;
            employ2.Name = "Kane Williamson";
            employ2.Basic = 81233;
            employ2.LeaveDays = 3;

            if (employ1.LeaveDays.HasValue)
            {
                Console.WriteLine("{0} has taken leave {1} days", employ1.Name, employ1.LeaveDays);
                employ1.LeaveStatus = 1;
            }
            else
            {
                Console.WriteLine("{0} has not taken leave", employ1.Name);
                employ1.LeaveStatus = 0;
            }

            if (employ2.LeaveDays.HasValue)
            {
                Console.WriteLine("{0} has taken leave {1} days", employ2.Name, employ2.LeaveDays);
                employ2.LeaveStatus = 1;
            }
            else
            {
                Console.WriteLine("{0} has not taken leave", employ2.Name);
                employ2.LeaveStatus = 0;
            }

        }

    }
}
