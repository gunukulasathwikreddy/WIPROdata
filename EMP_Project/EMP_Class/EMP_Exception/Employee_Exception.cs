using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMP_Exception
{
    public class Employee_Exception : ApplicationException
    {
        public Employee_Exception(string error) : base(error) 
        {
        
        }
    }
}
