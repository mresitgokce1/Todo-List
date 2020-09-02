using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo_List.DAL.Entities;
using Todolist.BLL.Abstract;

namespace Todo_List.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<Users> _userManager;


        public UserController(IRepository<Users> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserList()
        {
            ViewBag.UserList = _userManager.List();
            return View();
        }
        public IActionResult UserRole()
        {
            return View();
        }

        public IActionResult UserDelete(int id)
        {
            var user = _userManager.GetById(id);
            _userManager.Delete(user);
            return RedirectToAction("UserList");
        }
    }
}
