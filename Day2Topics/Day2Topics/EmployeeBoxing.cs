using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2Topics
{
    internal class EmployeeBoxing
    {
        public void EmpBoxShow(object ob)
        {
            string type = ob.GetType().Name;
            if(type.Equals("Employee"))
            {
                Employee emp = (Employee)ob;
                Console.WriteLine("Employee empno is : " + emp.empno);
                Console.WriteLine("Employee name is : " + emp.name);
            }
        }

        static void Main()
        {
            Employee obj = new Employee();
            obj.empno = 1;
            obj.name = "abc";

            EmployeeBoxing employeeBoxing = new EmployeeBoxing();
            employeeBoxing.EmpBoxShow(obj);


        }
    }
}
