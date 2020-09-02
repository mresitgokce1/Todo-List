using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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


        public IActionResult Index()
        {
            ViewBag.Users = _userManager.List();
            return View();
        }

        public IActionResult Users()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
