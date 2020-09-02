using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TodoList.DAL.EntitiyFramework;

namespace Todolist.BLL.Abstract
{
    public class Repository<T>: IRepository<T> where T : class
    {

        protected TodoListDbContext _context;
        private DbSet<T> _dbSet;

        public Repository(TodoListDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public List<T> List()
        {
            return _context.Set<T>().ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            Save();
        }

        public void Update(T obj)
        {
            Save();
        }

        public void Delete(T obj)
        {
            _context.Set<T>().Remove(obj);
            Save();
        }

        public T GetById(int Id)
        {
            return _context.Set<T>().Find(Id);
        }
    }
}
