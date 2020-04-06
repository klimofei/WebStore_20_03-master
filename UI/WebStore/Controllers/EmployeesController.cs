using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Domain.Entities.Identity;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    //[Route("users")]
    [Authorize]
    public class EmployeesController : Controller
    {

        private readonly IEmployeesData _EmployeesData;

        public EmployeesController(IEmployeesData EmployeesData) => _EmployeesData = EmployeesData;

        // [Route("employees")]
        public IActionResult Index() => View(_EmployeesData.GetAll().Select(e => new EmployeeViewModel
        {
            Id = e.Id,
            Name = e.FirstName,
            SecondName = e.SurName,
            Patronymic = e.Patronymic,
            Age = e.Age
        }));

        public IActionResult Details(int Id)
        {
            var employee = _EmployeesData.GetById(Id);
            if (employee is null)
                return NotFound();
            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.FirstName,
                SecondName = employee.SurName,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            });
        }

        //[Route("employee/{Id}")]
        [Authorize(Roles = Role.Administrator)]
        public IActionResult Edit(int? Id)
        {

            if (Id is null)
                return View(new EmployeeViewModel());

            if (Id < 0)
                return BadRequest();

            var employee = _EmployeesData.GetById((int)Id);
            if (employee is null)
                return NotFound();

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.FirstName,
                SecondName = employee.SurName,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            });
        }

        [Authorize(Roles = Role.Administrator)]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel Employee)
        {

            if (Employee is null)
                throw new ArgumentNullException(nameof(Employee));

            if (!ModelState.IsValid)
                return View(Employee);

            var id = Employee.Id;

            if (id == 0)
                _EmployeesData.Add(new Employee
                {
                    Id = Employee.Id,
                    FirstName = Employee.Name,
                    SurName = Employee.SecondName,
                    Patronymic = Employee.Patronymic,
                    Age = Employee.Age
                });
            else
                _EmployeesData.Edit(id, new Employee
                {
                    Id = Employee.Id,
                    FirstName = Employee.Name,
                    SurName = Employee.SecondName,
                    Patronymic = Employee.Patronymic,
                    Age = Employee.Age
                });

            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Create()
        {
            return View(new EmployeeViewModel());

        }

        [Authorize(Roles = Role.Administrator)]
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel Employee)
        {
            if (Employee is null)
                throw new ArgumentNullException(nameof(Employee));


            // Собственная ошибка:
            if (Employee.Name == "123" && Employee.SecondName == "QWE")
                ModelState.AddModelError(string.Empty, "Странные имя и фамилия...");

            if (!ModelState.IsValid)
                return View(Employee);

            _EmployeesData.Add(new Employee
            { 
                Id = Employee.Id,
                FirstName = Employee.Name,
                SurName = Employee.SecondName,
                Patronymic = Employee.Patronymic,
                Age = Employee.Age
            });

            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");

        }

        [Authorize(Roles = Role.Administrator)]
        public IActionResult Delete(int id)
        {
            // Через Get запрос
            //_EmployeesData.Delete(id);
            //return RedirectToAction("Index");

            if (id <= 0) return BadRequest();

            var employee = _EmployeesData.GetById(id);
            if (employee is null)
                return NotFound();

            return View(new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.FirstName,
                SecondName = employee.SurName,
                Patronymic = employee.Patronymic,
                Age = employee.Age
            });

        }

        [Authorize(Roles = Role.Administrator)]
        public IActionResult DeleteConfirmed(int id)
        {
            _EmployeesData.Delete(id);
            _EmployeesData.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}