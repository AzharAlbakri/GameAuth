using GameAuth.Entities.Interface;
using GameAuth.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GameAuth.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public static List<T> _entities = new();
        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _entities.AddRange(entities);
        }

        public IEnumerable<T> Find(Func<T, bool> expression)
        {
           return _entities.Where(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }

        public T GetById(Guid id)
        {
            return _entities.Find(e => e.Id == id);
        }

        
        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }


    
    }
}
