using ABB.Flisr.Models;
using System.Collections.Generic;

namespace ABB.Flisr.IServices
{
    public interface IEntitiesService<TEntity>
         where TEntity : Base
    {
        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(int id);
    }
}
