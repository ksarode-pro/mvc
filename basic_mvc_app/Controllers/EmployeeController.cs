using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using basic_mvc_app.Models;
using System.Runtime.CompilerServices;
using BasicMvcApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http.HttpResults;

namespace basic_mvc_app.Controllers;

public class EmployeeController : Controller
{
    private readonly ILogger<EmployeeController> _logger;
    private AppDbContext _dbcontext;

    public EmployeeController(ILogger<EmployeeController> logger, AppDbContext dbContext)
    {
        _logger = logger;
        _dbcontext = dbContext;
    }
    public IActionResult Index()
    {
        List<Employee> employees = _dbcontext.Employees.AsNoTracking().ToList();
        return View(employees);
    }

    public IActionResult Create()
    {
        return View();
    }


    public IActionResult Details(int id)
    {
        var employee = _dbcontext.Employees.AsNoTracking().FirstOrDefault(e => e.Id == id);
        return View(employee);
    }

    public IActionResult Edit(int id)
    {
        var employee = _dbcontext.Employees.Find(id);
        if (employee == null)
        {
            return NotFound();
        }
        return View(employee);
    }

    [HttpPut]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Employee employee)
    {
        if (employee == null)
        {
            return NotFound();
        }
        _dbcontext.Employees.Update(employee);
        _dbcontext.SaveChanges();
        return RedirectToAction("Details", new { Id = employee.Id });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Employee emp)
    {
        if (emp == null)
        {
            return StatusCode(500);
        }
        //example of adding custom error in model state.
        if (emp.FirstName == emp.LastName)
        {
            ModelState.AddModelError("LastName", "First and Last name cannot be same");
        }

        if (ModelState.IsValid)
        {
            _dbcontext.Employees.Add(emp);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete([FromForm] int id)
    {
        Employee emp = new Employee
        {
            Id = id
        };
        _dbcontext.Entry(emp).State = EntityState.Deleted;
        var result = _dbcontext.SaveChanges();
        if (result != null && result > 0)
        {
            TempData["success"] = "Data deleted successfully";
        }
        return RedirectToAction("Index");
    }

}
