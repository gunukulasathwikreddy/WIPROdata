using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPWithout
{
    internal class Sachin : IEmployDetails
    {
        public void AccountDetails()
        {
            throw new NotImplementedException();
        }

        public void PersonalDetails()
        {
            Console.WriteLine("Hi I am Sachin...");
        }

        public void ProjectDetails()
        {
            throw new NotImplementedException();
        }
    }
}
