using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Day5Part2
{
    [Serializable]
    class Employee
    { 
        public int Num {  get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return "Num : " + Num + " , Name :  " + Name;
        }
    }

    internal class E_SerializeEg
    {
        static void Main()
        {
            Employee emp = new Employee();
            emp.Num = 10;
            emp.Name = "Sachin Tendulkar";


            FileStream fs = new FileStream(@"E:\WIPROSkillingPrograms\FileObjects.txt", FileMode.Create,FileAccess.Write);
            BinaryFormatter bnformat = new BinaryFormatter();
            bnformat.Serialize(fs, emp);
            
            fs.Close();

            Console.WriteLine("Serialization Complete");

            Console.WriteLine("-------------------------------------------------------------");

            Console.WriteLine("Now Let us Do Deserialization and print the details :- ");

            FileStream ft = new FileStream(@"E:\WIPROSkillingPrograms\FileObjects.txt", FileMode.Open, FileAccess.Read);
            BinaryFormatter binaryft = new BinaryFormatter();
            Employee employee = (Employee)binaryft.Deserialize(ft);
            Console.WriteLine(employee);

            
            

            ft.Close();
        }
    }
}
