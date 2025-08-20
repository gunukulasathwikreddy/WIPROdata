using Microsoft.AspNetCore.Mvc;

namespace MvcDemoCore.Controllers
{
    public class SampleController : Controller
    {
        public string Index()
        {
            return "Welcome to Sample Controller";
        }

        public string Rajesh()
        {
            return "Hi I am Rajesh from .NET Full Stack Batch... From Sample Controller";
        }

        public string Greeting()
        {
            int hr = DateTime.Now.Hour;
            if (hr < 12)
            {
                return "Good Morning... From Sample Controller";
            }
            if (hr >= 12 && hr < 16)
            {
                return "Good Afternoon... From Sample Controller";
            }
            if (hr >= 16)
            {
                return "Good Evening... From Sample Controller";
            }
            return "";
        }

        public string Datta()
        {
            return "Hi I am Dev Datta... From Sample Controller";
        }
    }
}
