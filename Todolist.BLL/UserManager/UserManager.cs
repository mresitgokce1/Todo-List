using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using Todo_List.DAL.Entities;
using Todolist.BLL.Abstract;
using TodoList.DAL.EntitiyFramework;

namespace Todolist.BLL.UserManager
{
   public class UserManager : Repository<Users>
    {
        private TodoListDbContext _context;


        public UserManager(TodoListDbContext context) : base(context)
        {
            _context = context;
        }


        public bool CheckUser(string userName)
        {
            return _context.Users.Any(b => b.userName == userName);
        }

   
        public Users FindUser(string userName)
        {
            return _context.Users.Single(b => b.userName == userName);
        }

        public bool CheckUserPass(Users user, string password)
        {
            return user.password == password;

        }




    }
}
