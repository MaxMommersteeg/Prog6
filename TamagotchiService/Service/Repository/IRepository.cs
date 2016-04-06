using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TamagotchiService.Repository {
    public interface IRepository<TEntity> where TEntity : class {
        //Get id
        TEntity Get(int id);
        //Get All objects
        IEnumerable<TEntity> GetAll();
        //Find specific ovject using linq query
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        //adding or updating single entity
        void AddOrUpdate(TEntity entity);
        //adding single entity
        void Add(TEntity entity);
        //adding list entities
        void AddRange(IEnumerable<TEntity> entities);
        //remove single entity
        void Remove(TEntity entity);
        //remove list entities
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
