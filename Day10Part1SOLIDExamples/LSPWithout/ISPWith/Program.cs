using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPWith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sachin sachin = new Sachin();
            sachin.ShowPersonalInfo();
            Kane kane = new Kane();
            kane.ShowPersonalInfo();
            kane.ProjectName();
            kane.BillingInfo();
        }
    }
}
