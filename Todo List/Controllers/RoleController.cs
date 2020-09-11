using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todo_List.DAL.Entities;
using Todolist.BLL.RoleManager;
using TodoList.DAL.EntitiyFramework;

namespace Todo_List.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager _roleManager;

        public RoleController(RoleManager roleManager)
        {
            _roleManager = roleManager;
        }


        public IActionResult ListRoles()
        {
            var roles = _roleManager.List();
            ViewBag.listRoles = roles;
            return View();
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateRole(UserRoles userRole)
        {
            _roleManager.Insert(userRole);
            return RedirectToAction("ListRoles");
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var updateRole = _roleManager.GetById(id);
            ViewBag.editRole = updateRole;
            TempData["RoleID"] = updateRole.roleId;
            return View();
        }

        [HttpPost]
        public IActionResult UpdateRole(UserRoles userRole)
        {
            var roleId = TempData["RoleId"];
            var role = _roleManager.GetById(Convert.ToInt32(roleId));
            role.roleName = userRole.roleName;
            _roleManager.Update(role);
            return RedirectToAction("ListRoles");
        }

        public IActionResult DeleteRole(int id)
        {
            var deleteRole = _roleManager.GetById(id);
            _roleManager.Delete(deleteRole);
            return RedirectToAction("ListRoles");
        }
    }
}
