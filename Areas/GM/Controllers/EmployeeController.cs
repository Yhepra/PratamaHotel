using Microsoft.AspNetCore.Authorization;
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
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (!ModelState.IsValid) return View();



            return View();
        }
    }
}
