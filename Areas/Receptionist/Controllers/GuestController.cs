using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PratamaHotel.Models;
using PratamaHotel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PratamaHotel.Areas.Receptionist.Controllers
{
    [Authorize(Roles = "Receptionist")]
    [Area("Receptionist")]

    public class GuestController : Controller
    {
        private readonly IService _service;

        public GuestController(IService s)
        {
            _service = s;
        }
        public IActionResult Index()
        {
            var data = _service.GetGuest().ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _service.CreateGuest(guest);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int id)
        {
            var cari = _service.GetGuestByID(id);
            return cari == null ? NotFound() : View(cari);
        }

        [HttpPost]
        public IActionResult Update(Guest guest)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateGuest(guest);
                return RedirectToAction("Index");
            }
            return View(guest);
        }

        public IActionResult Delete(int id)
        {
            _service.DeleteGuest(id);
            return RedirectToAction("Index");
        }
    }
}
