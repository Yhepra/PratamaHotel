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

    public class RoomController : Controller
    {
        private readonly IService _service;

        public RoomController(IService s)
        {
            _service = s;
        }
        public IActionResult Index()
        {
            var data = _service.GetRoom();
            return View(data);
        }

        public IActionResult Create() {
            var rt = _service.GetRoomTypes().ToList();
            ViewBag.roomtype = rt;
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomForm data) {
            if (ModelState.IsValid)
            {
                var ro = new Room()
                {
                    idRoom = data.idRoom
                };

                var tr = _service.GetRoomTypes().FirstOrDefault(x => x.id == data.roomType);

                if (tr != null)
                {
                    ro.roomType = tr;
                }

                _service.CreateRoom(ro);

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(string id) {
            var rt = _service.GetRoomTypes().ToList();
            ViewBag.roomtype = rt;
            var cari = _service.GetRoomByID(id);
            return cari == null ? NotFound() : View(cari);
        }

        [HttpPost]
        public IActionResult Update(Room data)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateRoom(data);
                return RedirectToAction("Index");
            }
            return View(data);
        }

        public IActionResult Delete(string id)
        {
            _service.DeleteRoom(id);
            return RedirectToAction("Index");
        }
    }
}
