using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5Part1
{
    class FilterExceptionExample : ApplicationException
    {
        public FilterExceptionExample(string message) : base(message)
        {
        }
    }

    class Filtercls
    {
        public void ShowSeverity(string n)
        {
            if(n.Equals("low"))
            {
                throw new FilterExceptionExample("low severity. you can ignore for time being.");
            }
            else if (n.Equals("medium"))
            {
                throw new FilterExceptionExample("medium severity. you should try to solve this!");
            }
            else if (n.Equals("critical"))
            {
                throw new FilterExceptionExample("critical severity. stop all works and fix this now!!");
            }
            else
            {
                throw new FilterExceptionExample("No Error Occurred");
            }
        }
    }
    internal class A_FilterException
    {
        static void Main(string[] args)
        {
            Console.Write("Enter severity(low/medium/critical) : ");
            string severity = Console.ReadLine();
            Filtercls obj = new Filtercls();
            try
            {
                obj.ShowSeverity(severity);
            }
            catch (FilterExceptionExample e) when (e.Message.Contains("low"))
            {
                Console.WriteLine(e.Message);
            }
            catch (FilterExceptionExample e) when (e.Message.Contains("medium"))
            {
                Console.WriteLine(e.Message);
            }
            catch (FilterExceptionExample e) when (e.Message.Contains("critical"))
            {
                Console.WriteLine(e.Message);
            }
            catch (FilterExceptionExample e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
