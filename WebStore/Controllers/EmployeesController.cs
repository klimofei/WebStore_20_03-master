using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    //[Route("users")]
    public class EmployeesController : Controller
    {
        private static readonly List<Employee> __Employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                SurName = "Иванов",
                FirstName = "Иван",
                Patronymic = "Иванович",
                Age = 39
            },
            new Employee
            {
                Id = 2,
                SurName = "Петров",
                FirstName = "Пётр",
                Patronymic = "Петрович",
                Age = 18
            },
            new Employee
            {
                Id = 3,
                SurName = "Сидоров",
                FirstName = "Сидор",
                Patronymic = "Сидорович",
                Age = 27
            },
        };

       // [Route("employees")]
        public IActionResult Index() => View(__Employees);

        public IActionResult Details(int Id)
        {
            var employee = __Employees.FirstOrDefault(e => e.Id == Id);
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
                Id = __Employees.Count + 1,
                Age = 44
            };
            __Employees.Add(employee);
            return View(employee);
        }

    }
}