using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Todo_List.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        public IActionResult AddTodo()
        {
            return View();
        }

        public IActionResult DeleteTodo()
        {
            return View();
        }

        public IActionResult ListTodo()
        {
            return View();
        }

        public IActionResult UpdateTodo()
        {
            return View();
        }
    }
}
