using EMP_Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EMP_DAO
{
    public class EmployeeDAO : ItfEmployee_DAO
    {
        static List<Employee_Class> Emplist;

        static EmployeeDAO()
        {
            Emplist = new List<Employee_Class>();
        }

        public string AddEmp(Employee_Class emp)
        {
            Emplist.Add(emp);
            return "Employ Record Inserted...";
        }

        public void DeleteDAO(int num)
        {
            Employee_Class emp = SearchEmp(num);
            if (emp != null)
            {
                Emplist.Remove(emp);
                Console.WriteLine("Employee data deleted Successfully!!");
            }
            else
            {
                Console.WriteLine("Employee Record not found. Delete not possible");
            }
        }

        public void ReadDAO()
        {
            FileStream fs = new FileStream(@"E:\WIPROSkillingPrograms\Emp.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter formatter = new BinaryFormatter();
            Emplist = (List<Employee_Class>)formatter.Deserialize(fs);
            fs.Close();
            Console.WriteLine("Data Retrieved from the File Successfully...");
        }

        public Employee_Class SearchEmp(int num)
        {
            Employee_Class employFound = null;
            foreach (Employee_Class obj in Emplist)
            {
                if (obj.Empno == num )
                {
                    employFound = obj;
                    break;
                }
            }
            return employFound;
        }

        public List<Employee_Class> ShowEmp()
        {
            return Emplist;
        }

        public void UpdateDAO(Employee_Class emp)
        {
            Employee_Class e = SearchEmp(emp.Empno);
            if (e != null)
            {
                e.Name = emp.Name;
                e.Gender = emp.Gender;
                e.Dept = emp.Dept;
                e.Desig = emp.Desig;
                e.Basic = emp.Basic;
                Console.WriteLine("Updated Successfully");
            }
            else
            {
                Console.WriteLine("No Employee record with Employee Number "+emp.Empno+" found");
            }
        }

        public void WriteDAO()
        {
            FileStream fs = new FileStream(@"E:\WIPROSkillingPrograms\Emp.txt", FileMode.Create, FileAccess.Write);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, Emplist);
            fs.Close();
            Console.WriteLine("Data Stored in Files Successfully...");
        }
    }
}
