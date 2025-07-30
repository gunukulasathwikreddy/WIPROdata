using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Permissions;

using System.Reflection;

namespace Day9Part2
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method |AttributeTargets.Constructor, AllowMultiple = true)]
    public class InformationAttribute : Attribute
    {
        public string InformationString { get; set; }
    }


    [Information(InformationString = "Class")]
    public class Student
    {
        private int sno;
        private string name;

        [Information(InformationString = "Constructor")]
        public Student(int sno, string name)
        {
            this.sno = sno;
            this.name = name;
        }

        [Information(InformationString = "Method")]
        public void Display()
        {
            Console.WriteLine("Sno " + sno + " Name  " + name);
        }
    }


    internal class AttributeEg1
    {
        static void Main(string[] args)
        {
            Type obj = typeof(Student);
            Assembly exec = Assembly.GetExecutingAssembly();
            Type[] types = exec.GetTypes();
            foreach (var v in types)
            {
                foreach (var a in v.GetCustomAttributes())
                {
                    Console.WriteLine(a.TypeId);
                }
            }
        }
    }
}
