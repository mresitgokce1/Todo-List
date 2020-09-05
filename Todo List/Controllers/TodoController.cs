﻿using System;
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
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddTodo()
        {
            return View();
        }
    }
}
