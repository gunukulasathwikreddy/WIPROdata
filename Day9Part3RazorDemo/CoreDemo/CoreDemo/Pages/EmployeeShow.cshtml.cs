using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreDemo.Pages
{
    public class EmployeeShowModel : PageModel
    {
        public List<Employee>? EmpList { get; set; }
        public void OnGet()
        {
            EmpList = new List<Employee>
            {
                new Employee { Empno = 10, Name = "Sachin Tendulkar", Basic = 78965.9217 },
                new Employee { Empno = 22, Name = "Kane Williamson", Basic = 81917.61 },
                new Employee { Empno = 64, Name = "Yashasvi Jaiswal", Basic = 68181.89 },
                new Employee { Empno = 88, Name = "Nitish Kumar Reddy", Basic = 89658.86 },
            };
        }
    }
}
