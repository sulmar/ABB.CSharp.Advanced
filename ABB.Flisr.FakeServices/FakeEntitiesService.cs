using ABB.Flisr.IServices;
using ABB.Flisr.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABB.Flisr.FakeServices
{
    public class FakeEntitiesService<TEntity> : IEntitiesService<TEntity>
        where TEntity : Base
        
    {
        protected ICollection<TEntity> entities;

        //public TEntity Create()
        //{
        //    return new TEntity();
        //}

        public void Add(TEntity entity) => entities.Add(entity);

        public IEnumerable<TEntity> Get() => entities.Where(e => e.Id > 0).ToList();

        public TEntity Get(int id)
        {
            return entities.SingleOrDefault(p => p.Id == id);
        }

        public virtual void Remove(int id) => entities.Remove(Get(id));

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
