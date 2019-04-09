using ABB.Flisr.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ABB.Flisr.IServices
{
    public interface IUsersService : IEntitiesService<User>
    {
        
    }

    public interface IEntitiesService<TEntity>
         where TEntity : Base
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
    }

    public interface ICustomersService : IEntitiesService<Customer>
    {
        IEnumerable<Customer> GetByCity(string city);
    }
}
