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
        private readonly EmailService _email;

        public EmployeeController(IService s, EmailService em)
        {
            _service = s;
            _email = em;
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
                _email.SendEmail(emp.email, "Pendaftaran Berhasil!", "Berikut adalah ID dan password anda<br><br><table><tr><td>ID</td><td>" + emp.id + "</td></tr><tr><td>Password</td><td>" + emp.password + "</td></tr></table>");

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
