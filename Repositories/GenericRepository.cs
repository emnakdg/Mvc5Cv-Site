﻿using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MvcCv.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCvEntities db = new DbCvEntities();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T entity)
        {
            db.Set<T>().Add(entity);
            db.SaveChanges();
        }

        public void TUpdate(T entity)
        {
            db.SaveChanges();
        }

        public void TDelete(T entity)
        {
            db.Set<T>().Remove(entity);
            db.SaveChanges();
        }

        public T TGetById(int id)
        {
            return db.Set<T>().Find(id);
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}