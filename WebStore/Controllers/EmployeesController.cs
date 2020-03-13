﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Data;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    //[Route("users")]
    public class EmployeesController : Controller
    {

        private readonly IEmployeesData _EmployeesData;

        public EmployeesController(IEmployeesData EmployeesData) => _EmployeesData = EmployeesData;

        // [Route("employees")]
        public IActionResult Index() => View(_EmployeesData.GetAll());

        public IActionResult Details(int Id)
        {
            var employee = _EmployeesData.GetById(Id);
            if (employee is null)
                return NotFound();
            return View(employee);
        }

        //[Route("employee/{Id}")]
        //public IActionResult AddEmployee()
        //{
        //    var employee = new Employee()
        //    {
        //        FirstName = "Новый сотрудник",
        //        SurName = "Новый сотрудник",
        //        Patronymic = "Новый сотрудник",
        //        Id = TestData.Employees.Count + 1,
        //        Age = 44
        //    };
        //    TestData.Employees.Add(employee);
        //    return View(employee);
        //}

        public IActionResult Edit(int? Id)
        {

            if (Id is null) 
                return View(new Employee());

            if (Id < 0) 
                return BadRequest();

            var employee = _EmployeesData.GetById((int)Id);
            if (employee is null)
                return NotFound();

            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee Employee)
        {

            if (Employee is null)
                throw new ArgumentNullException(nameof(Employee));

            if (!ModelState.IsValid)
                return View(Employee);

            var id = Employee.Id;

            if (id == 0)
                _EmployeesData.Add(Employee);
            else
                _EmployeesData.Edit(id, Employee);

            _EmployeesData.SaveChanges();

            return RedirectToAction("Index");

            //if (Id is null)
            //    return View(new Employee());

            //if (Id < 0)
            //    return BadRequest();

            //var employee = _EmployeesData.GetById((int)Id);
            //if (employee is null)
            //    return NotFound();

            //return View(employee);
        }

    }
}