using Book_Store.Core.Consts;
using Book_Store.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.EF.Reposatory
{
    public class BaseReposatory<T> : IBaseReposatory<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public BaseReposatory(ApplicationDbContext context)
        {
            _context = context;
        }

        public T Get(int id) => _context.Set<T>().Find(id);

        public IEnumerable<T> GetAll() =>_context.Set<T>().ToList();
        public T Find(Expression<Func<T, bool>> expression, string[] includes= null)
        {
            IQueryable<T> entity = _context.Set<T>();
            if(includes != null)
            {
                foreach (var include in includes)
                    entity = entity.Include(include);
                
                
            }
            return entity.SingleOrDefault(expression);
        }   
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> expression, string[] includes= null)
        {
            IQueryable<T> entity = _context.Set<T>();
            if(includes != null)
            {
                foreach (var include in includes)
                    entity = entity.Include(include);
                
                
            }
            return entity.Where(expression).ToList();
        } 
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> expression, string[]? includes = null,int? skip = null, int? take = null,
            Expression<Func<T, object>>? orderBy = null,
            string order = Order.Ascending)
        {
            IQueryable<T> query = _context.Set<T>();
            if(includes != null)
            {
                foreach (var include in includes)
                    query = query.Include(include);
            }
            query.Where(expression).ToList();

            if (skip != null)
                query = query.Skip(skip.Value);
            if (take != null)
                query = query.Take(take.Value);
            
            if (orderBy != null)
            {
                if (order == Order.Ascending)
                {
                    query = query.OrderBy(orderBy);
                }
                else
                    query = query.OrderByDescending(orderBy);
            }

            return query.ToList();
        }
        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
            return entities;
        }
    }
}
