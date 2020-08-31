using System;
using System.Collections.Generic;
using System.Text;

namespace Todolist.BLL.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        void Save();
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
        T GetById(int Id);
    }
}
