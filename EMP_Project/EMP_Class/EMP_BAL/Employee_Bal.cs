using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EMP_Class;
using EMP_DAO;
using EMP_Exception;

namespace EMP_BAL
{
    public class Employee_Bal
    {
        public static EmployeeDAO DAO_Obj;
        static Employee_Bal()
        {
            DAO_Obj = new EmployeeDAO();
        }

        public List<Employee_Class> ShowEmp()
        { 
            return DAO_Obj.ShowEmp();
        }

        public Employee_Class SearchEmp(int num)
        {
            return DAO_Obj.SearchEmp(num);
        }

        public StringBuilder strbd = new StringBuilder();
        public bool ValEmp(Employee_Class obj)
        {
            strbd.Clear();
            bool flag = true;
            if (obj.Empno <= 0)
            {
                strbd.Append("Employ No Cannot be Zero or Negative...\n");
                flag = false;
            }
            if (obj.Name.Length < 5)
            {
                strbd.Append("Name Contains Min. 5 characters...\n");
                flag = false;
            }
            if (obj.Basic < 10000 || obj.Basic > 80000)
            {
                strbd.Append("Basic Must be Between 10000 and 80000...\n");
                flag = false;
            }
            return flag;
        }
        public string AddEmployee(Employee_Class emp)
        {
            if (ValEmp(emp))
            {
                return DAO_Obj.AddEmp(emp);
            }
            throw new Employee_Exception(strbd.ToString());
        }

        public void UpdateEmpBal(Employee_Class emp)
        {
            if(ValEmp(emp))
            {
                DAO_Obj.UpdateDAO(emp);
            }
            throw new Employee_Exception(strbd.ToString());
        }

        public void DeleteBal(int num)
        {
            DAO_Obj.DeleteDAO(num);
        }

        public void WriteFileBal()
        {
            DAO_Obj.WriteDAO();
        }

        public void ReadFileBal()
        {
            DAO_Obj.ReadDAO();
        }

    }
}
