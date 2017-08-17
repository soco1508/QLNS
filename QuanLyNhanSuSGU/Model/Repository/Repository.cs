﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Model.Entities;

namespace Model.Repository
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Delete(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(int id);
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        protected DbSet<T> _DbSet;
        protected QuanLyNhanSuSGUEntities _db;

        public Repository(QuanLyNhanSuSGUEntities db)
        {
            _DbSet = db.Set<T>();
            _db = db;
        }

        #region IRepository<T> Members

        public void Insert(T entity)
        {
            _DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _DbSet.Remove(entity);
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return _DbSet.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _DbSet;
        }

        public T GetById(int id)
        {
            return _DbSet.Find(id);
        }

        #endregion
    }
}
