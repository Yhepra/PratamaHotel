using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PratamaHotel.Helper;
using PratamaHotel.Models;
using PratamaHotel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PratamaHotel.Controllers
{
    public class AccountController : Controller
    {
        private readonly IService _service;

        public AccountController(IService s)
        {
            _service = s;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Employee data)
        {
            if(!ModelState.IsValid) return View();

            var dt = _service.GetEmployeeByID(data.id);

            if (dt == null)
            {
                ViewBag.message = "ID tidak ditemukan";
                return View(data);
            }

            dt = _service.GetEmployeeByIDAndPassword(dt.id, dt.password);

            if(dt == null)
            {
                ViewBag.message = "Password salah";
                return View(data);
            }

            var reg = General.CreateKlaim(dt.id, dt.role.name);

            await HttpContext.SignInAsync(
                new ClaimsPrincipal(
                    new ClaimsIdentity(reg, "Cookie", "id", "role")
                    )
                );

            if (dt.role.name == "General Manager") return Redirect("/GM/Home");
            else if (dt.role.name == "Receptionist") return Redirect("/Receptionist/Home");
            else return Redirect("/");
        }
        
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
