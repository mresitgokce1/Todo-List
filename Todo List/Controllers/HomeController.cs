using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Todo_List.DAL.Entities;
using Todolist.BLL.Abstract;
using Todolist.BLL.UserManager;
using TodoList.DAL.EntitiyFramework;

namespace Todo_List.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager _userManager;


        public HomeController(UserManager userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users user)
        {
            if (!_userManager.CheckUser(user.userName))
            {
                _userManager.Insert(user);
                return RedirectToAction("Login");
            }
            else
            {
                return Ok("Böyle bir kullanıcı vardır.");
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Users user)
        {
            if (_userManager.UserLoginCheck(user))
            {
                var userClaims = new List<Claim>()
                {
                    new Claim("UserName", user.userName),
                };

                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return RedirectToAction("Dashboard");
            }

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
