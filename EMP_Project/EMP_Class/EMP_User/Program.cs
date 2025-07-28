using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EMP_Class;
using EMP_DAO;
using EMP_Exception;
using EMP_BAL;

namespace EMP_User
{
    internal class Program
    {
        static Employee_Bal EmployeeBal = new Employee_Bal();
        public static void AddEmpMain()
        {
            Employee_Class employ = new Employee_Class();

            Console.Write("Enter Employ Number : ");
            employ.Empno = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employ Name : ");
            employ.Name = Console.ReadLine();

            Console.Write("Enter Gender (MALE/FEMALE) : ");
            employ.Gender = Console.ReadLine();

            Console.Write("Enter Department : ");
            employ.Dept = Console.ReadLine();

            Console.Write("Enter Designation : ");
            employ.Desig = Console.ReadLine();

            Console.Write("Enter Basic : ");
            employ.Basic = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine(EmployeeBal.AddEmployee(employ));

        }

        public static void ShowEmpMain()
        {
            List <Employee_Class> emplist = new List <Employee_Class>();
            emplist = EmployeeBal.ShowEmp();
            foreach(Employee_Class emp in emplist)
            {
                Console.WriteLine (emp);
            }
        }

        public static void SearchEmpMain()
        {
            int empno;
            Console.Write("Enter Employ Number  : ");
            empno = Convert.ToInt32(Console.ReadLine());
            Employee_Class employ = EmployeeBal.SearchEmp(empno);
            if (employ != null)
            {
                Console.WriteLine(employ);
            }
            else
            {
                Console.WriteLine("*** Employ Record Not Found ***");
            }
        }

        public static void UpdateEmpMain()
        {
            Employee_Class employ = new Employee_Class();

            Console.Write("Enter Employ Number : ");
            employ.Empno = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Employ Name : ");
            employ.Name = Console.ReadLine();

            Console.Write("Enter Gender (MALE/FEMALE) : ");
            employ.Gender = Console.ReadLine();

            Console.Write("Enter Department : ");
            employ.Dept = Console.ReadLine();

            Console.Write("Enter Designation : ");
            employ.Desig = Console.ReadLine();

            Console.Write("Enter Basic : ");
            employ.Basic = Convert.ToDouble(Console.ReadLine());

            EmployeeBal.UpdateEmpBal(employ);

        }

        public static void DeleteMain()
        {
            Console.Write("Enter Employ Number : ");
            int num = Convert.ToInt32(Console.ReadLine());

            EmployeeBal.DeleteBal(num);
        }

        public static void WriteFile()
        {
            EmployeeBal.WriteFileBal();
        }

        public static void ReadFile()
        {
            EmployeeBal.ReadFileBal();
        }
        static void Main(string[] args)
        {
            int n;
            do
            {
                Console.WriteLine("O P T I O N S :- ");
                Console.WriteLine("1. Add Employ");
                Console.WriteLine("2. Show Employ");
                Console.WriteLine("3. Search Employ");
                Console.WriteLine("4. Update Employ");
                Console.WriteLine("5. Delete Employ");
                Console.WriteLine("6. Write to File");
                Console.WriteLine("7. Read From File");
                Console.WriteLine("Enter -1 to Exit");
                Console.WriteLine("-------------");
                Console.Write("Enter your Choice : ");
                n = Convert.ToInt32(Console.ReadLine());

                switch (n)
                {
                    case 1:
                        try
                        {
                            AddEmpMain();

                        }
                        catch (Employee_Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 2:
                        ShowEmpMain(); break;

                    case 3:
                        SearchEmpMain(); break;

                    case 4:
                        try
                        {
                           UpdateEmpMain();

                        }
                        catch (Employee_Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;

                    case 5: DeleteMain(); break;

                    case 6: WriteFile(); break;

                    case 7: ReadFile(); break;

                    case -1: Console.WriteLine("Program Exit"); break;

                    default: Console.WriteLine("Not a valid Choice"); break;
                }

            } while (n != -1);
        }
    }
}
