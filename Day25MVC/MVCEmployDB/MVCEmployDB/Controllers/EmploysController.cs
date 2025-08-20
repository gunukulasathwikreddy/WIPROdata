using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCEmployDB.Models;
using System.Linq;
using System.Threading.Tasks;

public class EmploysController : Controller
{
    private readonly EFCoreDbContext _context;

    public EmploysController(EFCoreDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Employees.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employ = await _context.Employees
            .FirstOrDefaultAsync(m => m.Empno == id);
        if (employ == null)
        {
            return NotFound();
        }

        return View(employ);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Empno,Name,Gender,Dept,Desig,Basic")] Employ employ)
    {
        if (ModelState.IsValid)
        {
            _context.Add(employ);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(employ);
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employ = await _context.Employees.FindAsync(id);
        if (employ == null)
        {
            return NotFound();
        }
        return View(employ);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int OriginalEmpno, [Bind("Empno,Name,Gender,Dept,Desig,Basic")] Employ employ)
    {
        if (!ModelState.IsValid)
        {
            return View(employ);
        }

        try
        {
            var existingEmploy = await _context.Employees.FindAsync(OriginalEmpno);
            if (existingEmploy == null)
            {
                return NotFound();
            }

            // Remove old record and add new one with updated Empno
            _context.Employees.Remove(existingEmploy);
            _context.Employees.Add(employ);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException ex)
        {
            ModelState.AddModelError("", "Unable to save changes: " + ex.Message);
            return View(employ);
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employ = await _context.Employees
            .FirstOrDefaultAsync(m => m.Empno == id);
        if (employ == null)
        {
            return NotFound();
        }

        return View(employ);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var employ = await _context.Employees.FindAsync(id);
        if (employ != null)
        {
            _context.Employees.Remove(employ);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EmployExists(int id)
    {
        return _context.Employees.Any(e => e.Empno == id);
    }
}
