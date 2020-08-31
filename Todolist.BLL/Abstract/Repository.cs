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
        private DbSet<T> _objectSet;

        private readonly TodoListDbContext _todoListDbContext;

        public Repository()
        {
            _objectSet = _todoListDbContext.Set<T>();
        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public void Save()
        {
            _todoListDbContext.SaveChanges();
        }

        public void Insert(T obj)
        {
            _objectSet.Add(obj);
            Save();
        }

        public void Update(T obj)
        {
            Save();
        }

        public void Delete(T obj)
        {
            _objectSet.Remove(obj);
            Save();
        }

        public T GetById(int Id)
        {
            return _objectSet.Find(Id);
        }
    }
}
