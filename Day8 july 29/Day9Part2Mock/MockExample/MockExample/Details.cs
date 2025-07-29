using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockExample
{
    public class Details : IDetails
    {
        public string ShowCompany()
        {
            return "WIPRO Hyderabad Branch";
        }

        public string ShowStudent()
        {
            return "Hello Student Method";
        }
    }
}
