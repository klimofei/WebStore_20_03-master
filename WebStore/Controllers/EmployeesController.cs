using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Models;

namespace WebStore.Controllers
{
    //[Route("users")]
    public class EmployeesController : Controller
    {
       

       // [Route("employees")]
        public IActionResult Index() => View(TestData.Employees);

        public IActionResult Details(int Id)
        {
            var employee = TestData.Employees.FirstOrDefault(e => e.Id == Id);
            if (employee is null)
                return NotFound();
            return View(employee);
        }

        //[Route("employee/{Id}")]
        public IActionResult AddEmployee()
        {
            var employee = new Employee()
            {
                FirstName = "Новый сотрудник",
                SurName = "Новый сотрудник",
                Patronymic = "Новый сотрудник",
                Id = TestData.Employees.Count + 1,
                Age = 44
            };
            TestData.Employees.Add(employee);
            return View(employee);
        }

    }
}