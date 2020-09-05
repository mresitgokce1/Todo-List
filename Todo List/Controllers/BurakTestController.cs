using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Todolist.BLL.UserManager;
using TodoList.DAL.EntitiyFramework;

namespace Todo_List.Controllers
{
    public class BurakTestController : Controller
    {
        private UserManager _userManager;
        public BurakTestController(UserManager userManager)
        {
        
            _userManager = userManager;
        }

        public IActionResult Giris(string userName, string password)
        {
            var kullaniciVarmi = _userManager.CheckUser(userName);
            if (!kullaniciVarmi) return BadRequest("Sistemde böyle bir kullanici yok");
            var kullanici = _userManager.FindUser(userName);
            var kullaniciSifreDogruMi = _userManager.CheckUserPass(kullanici, password);
            if (kullaniciSifreDogruMi)
            {
                return Ok("Kullanici girişi tamam.");
            }

            return BadRequest("Sisteme girş sağlanamadı.");

        }

    }
}
