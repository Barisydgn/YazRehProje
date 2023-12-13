using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories.Repositories.BaseRepo
{
    public interface IRepositoryBase<T>
    {
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        IQueryable<T> GetAll(bool trackChanges);
        IQueryable<T> GetById(Expression<Func<T, bool>> expression, bool trackChanges);

    }
}
