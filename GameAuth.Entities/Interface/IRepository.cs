using GameAuth.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameAuth.Entities.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(Guid id);
        //IQueryable<T> SearchQuery(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
    }
}
