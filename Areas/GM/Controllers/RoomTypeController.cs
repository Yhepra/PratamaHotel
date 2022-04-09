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

    public class RoomTypeController : Controller
    {
        private readonly IService _service;

        public RoomTypeController(IService s)
        {
            _service = s;
        }
        public IActionResult Index()
        {
            var data = _service.GetRoomTypes();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomType data) 
        {
            if (ModelState.IsValid) {
                _service.CreateRoomType(data);
            }
            return RedirectToAction("index");
        }
        public IActionResult Update(string id)
        {
            var cari = _service.GetRoomTypeByID(id);
            return cari == null ? NotFound() : View(cari);
        }

        [HttpPost]
        public IActionResult Update(RoomType data)
        {
            if (ModelState.IsValid) {
                _service.UpdateRoomType(data);
                return RedirectToAction("index");
            }
            return View(data);
        }

        public IActionResult Delete(string id)
        {
            _service.DeleteRoomType(id);
            return RedirectToAction("Index");
        }
    }
}
