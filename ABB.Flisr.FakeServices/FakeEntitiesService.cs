using ABB.Flisr.IServices;
using ABB.Flisr.Models;
using System;
using System.Collections.Generic;

namespace ABB.Flisr.FakeServices
{
    public class FakeEntitiesService<TEntity> : IEntitiesService<TEntity>
        where TEntity : Base
        
    {
        private ICollection<TEntity> entities;

        //public TEntity Create()
        //{
        //    return new TEntity();
        //}

        public void Add(TEntity entity)
        {
            entities.Add(entity);
        }
    
        public IEnumerable<TEntity> Get()
        {
            return entities;
        }

        public TEntity Get(int id)
        {
            return entities.SingleOrDefault(p => p.Id == id);
        }

        public virtual void Remove(int id)
        {
            TEntity entity = Get(id);
            entities.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
