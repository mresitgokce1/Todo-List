using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Todo_List.DAL.Entities;
using Todolist.BLL.Abstract;
using TodoList.DAL.EntitiyFramework;

namespace Todolist.BLL.RoleManager
{
    public class RoleManager : Repository<UserRoles>
    {
        private TodoListDbContext _context;

        public RoleManager(TodoListDbContext context) : base(context)
        {
            _context = context;
        }

        public bool CheckRole(string roleName)
        {
            return _context.UserRoles.Any(r => r.roleName == roleName);
        }

        public UserRoles FindRole(string roleName)
        {
            return _context.UserRoles.Single(r => r.roleName == roleName);
        }

        public override UserRoles GetById(int Id)
        {
            return _context.UserRoles.Include(a => a.users).Single(a => a.roleId == Id);
        }

        public UserRoles GetByIdBase(int id)
        {
            return base._context.UserRoles.Single(a => a.roleId == id);
        }
    }
}
