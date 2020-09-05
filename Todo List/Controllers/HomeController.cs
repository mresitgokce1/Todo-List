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
using TodoList.DAL.EntitiyFramework;

namespace Todo_List.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Users> _userManager;


        public HomeController(IRepository<Users> userManager)
        {
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            
            ViewBag.Users = _userManager.List();
            return View();
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
            foreach (var userName in _userManager.List())
            {
                if (userName.userName == user.userName)
                {
                    return View();
                }
            }
            _userManager.Insert(user);
            _userManager.Save();
            return RedirectToAction("Login");

        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Users user)
        {
          
            foreach (var users in _userManager.List())
            {
                if (users.userName == user.userName && users.password == user.password)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.userName),
                    };

                    var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
                    var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                    HttpContext.SignInAsync(userPrincipal);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
