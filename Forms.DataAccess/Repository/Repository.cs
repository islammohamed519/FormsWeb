
using Forms.DataAccess.Repository.IRepository;
using Forms.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forms.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DynamicFormsContext _context;
        internal DbSet<T> dbset;
        public Repository(DynamicFormsContext context)
        {
            _context = context;
            this.dbset = _context.Set<T>();
            ////_context.Form.Include(u => u.Tenant.Name).Include(c => c.Organization.Name).ToList();
        }
        public void Add(T entity)
        {
            dbset.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbset;
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbset;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }



        public T GetLastOrDefault()
        {
            IQueryable<T> query = dbset;

            return query.ToList().LastOrDefault();
        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbset.RemoveRange(entities);
        }
    }
}
