using MvcProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcProject.Repository
{
    public class GenericRepository<T> where T : class, new()
    {
        CvProjectMVCEntities db = new CvProjectMVCEntities();
        public List<T> List()
        {
            return db.Set<T>().ToList();
        }
        public void Add(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }
        public void Delete(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }
        public T Find(int id)
        {
            return db.Set<T>().Find(id);
        }
        public T FindWhere(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
        public void Update()
        {
            db.SaveChanges();
        }
    }
}