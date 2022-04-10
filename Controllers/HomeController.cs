using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PratamaHotel.Models;
using PratamaHotel.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PratamaHotel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IService _service;

        public HomeController(ILogger<HomeController> logger, IService s)
        {
            _logger = logger;
            _service = s;
        }

        public IActionResult Index()
        {
            int jmlkamar = _service.GetRoom().Count;
            int jmlemp = _service.GetAllEmployee().Count;
            ViewBag.jmlkamar = jmlkamar;
            ViewBag.jmlemp = jmlemp;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
