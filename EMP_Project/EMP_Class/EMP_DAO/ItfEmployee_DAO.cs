using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EMP_Class;

namespace EMP_DAO
{
    internal interface ItfEmployee_DAO
    {
        string AddEmp(Employee_Class emp);
        List<Employee_Class> ShowEmp();
        Employee_Class SearchEmp(int num);
        void UpdateDAO(Employee_Class emp);

        void DeleteDAO(int num);

        void WriteDAO();
        void ReadDAO();

    }

}
