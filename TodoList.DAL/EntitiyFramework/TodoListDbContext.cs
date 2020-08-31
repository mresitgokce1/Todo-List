using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Todo_List.DAL.Entities;

namespace TodoList.DAL.EntitiyFramework
{
    public class TodoListDbContext : DbContext
    {
        public TodoListDbContext(DbContextOptions<TodoListDbContext> options) 
            : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<TodoHeader> TodoHeader { get; set; }
        public DbSet<todoList> TodoList { get; set; }
    }
}
