using ABB.Flisr.Models;
using System.Collections.Generic;

namespace ABB.Flisr.IServices
{
    public interface ICustomersService : IEntitiesService<Customer>
    {
        IEnumerable<Customer> GetByCity(string city);
    }
}
