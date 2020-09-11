using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo_List.DAL.Entities;
using Todolist.BLL.Abstract;
using Todolist.BLL.RoleManager;
using Todolist.BLL.UserManager;

namespace Todo_List.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        public UserController(UserManager userManager, RoleManager roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult UserList()
        {
            ViewBag.UserList = _userManager.List();
            ViewBag.RoleList = _roleManager.List();
            return View();
        }

        public IActionResult UserDelete(int id)
        {
            var user = _userManager.GetById(id);
            _userManager.Delete(user);
            return RedirectToAction("UserList");
        }

        [HttpGet]
        public IActionResult UserUpdate(int id)
        {
            var user = _userManager.GetById(id);
            ViewBag.EditUser = user;
            return View();
        }

        [HttpPost]
        public IActionResult UserUpdate(Users user)
        {
            _userManager.Update(user);
            return RedirectToAction("UserList");
        }

        [HttpGet]
        public IActionResult UserCreate()
        {
            ViewBag.roles = _roleManager.List();
            return View();
        }

        [HttpPost]
        public IActionResult UserCreate(Users user)
        {
            ViewBag.roles = _roleManager.List();
            
            if (!_userManager.CheckUser(user.userName))
            {
                _userManager.Insert(user);
                return View();
            }
            
            return View();
        }

    }
}
