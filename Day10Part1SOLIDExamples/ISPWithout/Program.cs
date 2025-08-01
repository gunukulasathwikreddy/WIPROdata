using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPWithout
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEmployDetails obj = new Sachin();
            obj.PersonalDetails();
            obj.ProjectDetails();
            obj.AccountDetails();
        }
    }
}
