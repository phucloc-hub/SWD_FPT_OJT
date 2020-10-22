using Microsoft.EntityFrameworkCore;
using SWD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SWD_DEMO.Services
{
    public interface IBaseService<TEntity,TKey> where TEntity : class
    {
        TEntity GetByID(TKey id);
        TEntity GetByTwoID(Expression<Func<TEntity, bool>> exception);
        IEnumerable<TEntity> GetAll(int _pagenum, int _perpage, Expression<Func<TEntity, bool>> expression);
        IQueryable<TEntity> Entity();
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity Delete(TKey id);
        TEntity DeleteByEntity(TEntity entity);
        void Commit();
    }

    public class BaseService<TEntity, TKey> : IBaseService<TEntity, TKey> where TEntity : class
    {
        SWDContext _context;
        DbSet<TEntity> dbSet;
        private bool _disposed;
        public BaseService(SWDContext context)
        {
            this._context = _context ?? context;
            this.dbSet = _context.Set<TEntity>();
        }

        public TEntity Add(TEntity entity)
        {
            dbSet.Add(entity);
            return entity;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public TEntity Delete(TKey id)
        {
            var entity = GetByID(id);
            if (entity != null)
            {
                return dbSet.Remove(entity).Entity;
            }
            return null;
        }

        public TEntity DeleteByEntity(TEntity entity)
        {
            return dbSet.Remove(entity).Entity;
        }

        public IQueryable<TEntity> Entity()
        {
            return dbSet;
        }

        public IEnumerable<TEntity> GetAll(int _pagenum, int _perpage, Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression == null)
            {
                return dbSet.Skip((_pagenum - 1) * _perpage).Take(_perpage);
            }
            return dbSet.Where(expression).Skip(_pagenum * _perpage).Take(_perpage);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression == null)
            {
                return dbSet.ToList();
            }
            return dbSet.Where(expression).ToList();
        }


        public TEntity GetByID(TKey id)
        {
            return dbSet.Find(id);
        }

        public TEntity GetByTwoID(Expression<Func<TEntity, bool>> exception)
        {
            return dbSet.FirstOrDefault(exception);
        }

        public TEntity Update(TEntity entity)
        {
            var result = _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        }
    
}
