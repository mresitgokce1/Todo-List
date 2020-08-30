using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Todo_List.Models;

namespace Todo_List.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;

        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(Users user)
        {
            var userName = _dbContext.Users.FirstOrDefault().userName;
            var password = _dbContext.Users.FirstOrDefault().password;

            if (userName == user.userName && password == user.password)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }


        public IActionResult Users()
        {
            return View(_dbContext.Users.ToList());
        }

        


        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(Users users)
        {
            if (users.userName != _dbContext.Users.FirstOrDefault().userName)
            {
                _dbContext.Users.Add(users);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

        }
    }
}
