using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Repositories.BaseRepo
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly YazContext _context;

        protected RepositoryBase(YazContext context)
        {
            _context = context;
        }

        public void Create(T item) => _context.Set<T>().Add(item);

        public void Delete(T item) => _context.Set<T>().Remove(item);
        public IQueryable<T> GetAll(bool trackChanges) => trackChanges ? _context.Set<T>().AsNoTracking() : _context.Set<T>();

        public IQueryable<T> GetById(Expression<Func<T, bool>> expression, bool trackChanges) => trackChanges ? _context.Set<T>().Where(expression).AsNoTracking() : _context.Set<T>().Where(expression);
        public void Update(T item) => _context.Set<T>().Update(item);
    }
}
