using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PratamaHotel.Models;
using PratamaHotel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PratamaHotel.Areas.GM.Controllers
{
    [Authorize(Roles = "General Manager")]
    [Area("GM")]
    public class EmployeeController : Controller
    {
        private readonly IService _service;

        public EmployeeController(IService s)
        {
            _service = s;
        }

        public IActionResult Index()
        {
            var data = _service.GetAllEmployee();

            return View(data);
        }

        public IActionResult Create()
        {
            var role = _service.GetRoles().ToList();
            ViewBag.role = role;
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeForm employee, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee()
                {
                    name = employee.name,
                    address = employee.address,
                    email = employee.email,
                    password = employee.password,
                };

                var rl = _service.GetRoles().FirstOrDefault(x => x.id == employee.role);

                if(rl != null)
                {
                    emp.role = rl;
                }
                _service.CreateEmployee(emp, image);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Detail(string id)
        {
            var cari = _service.GetEmployeeByID(id);
            return cari == null ? NotFound() : View(cari);
        }

        public IActionResult Edit(string id)
        {
            var cari = _service.GetEmployeeByID(id);
            return cari == null ? NotFound() : View(cari);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateEmployee(employee, image);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        public IActionResult Delete(string id)
        {
            _service.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
