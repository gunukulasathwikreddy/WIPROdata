using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace Day9Part2
{
    [System.AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class VendorAttribute : Attribute
    {
        public string vendorName;
        public double premiumAmount;

        public VendorAttribute(string vendorName)
        {
            this.vendorName = vendorName;
            //this.premiumAmount = premiumAmount;
        }
    }

    [Vendor(vendorName: "Zomoto"), Vendor("AK Tifinis", premiumAmount = 88323.44)]
    public class Anubhav
    {
    }

    [Vendor(vendorName: "Swiggy")]
    public class Aarifa
    {
    }

    public class Demo
    {
        public static void PrintClassInfor(Type t)
        {
            MemberInfo memberInfo = t;
            object[] arr = memberInfo.GetCustomAttributes(typeof(VendorAttribute), false);
            foreach (object ob in arr)
            {
                VendorAttribute v = (VendorAttribute)ob;
                Console.WriteLine(v.vendorName);
                Console.WriteLine(v.premiumAmount);
            }
        }
    }
    internal class AttributeEg2
    {
        static void Main(string[] args)
        {
            Demo.PrintClassInfor(typeof(Anubhav));
            Demo.PrintClassInfor(typeof(Aarifa));
        }
    }
}
