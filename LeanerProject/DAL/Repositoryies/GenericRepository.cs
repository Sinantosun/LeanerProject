using LeanerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace LeanerProject.DAL.Repositoryies
{
    public class GenericRepository<T> where T : class
    {
        Context _context = new Context();

        public void Add(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
        }
        public void Delete(T t)
        {
            _context.Set<T>().Remove(t);
            _context.SaveChanges();
        }
        public void Update(T t)
        {
            _context.SaveChanges();
        }
        public T ByID(int id)
        {
            var value = _context.Set<T>().Find(id);
            return value;
        }
        public List<T> GetList()
        {
            var value = _context.Set<T>().ToList();
            return value;
        }
        public List<T> ByFilterList(Expression<Func<T,bool>> where)
        {
            var value = _context.Set<T>().Where(where).ToList();
            return value;
        }
        public T ByFilter(Expression<Func<T, bool>> where)
        {
            var value = _context.Set<T>().FirstOrDefault(where);
            return value;
        }
    }
}