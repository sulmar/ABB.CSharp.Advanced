using ABB.Flisr.IServices;
using ABB.Flisr.Models;
using System;
using System.Collections.Generic;

namespace ABB.Flisr.FakeServices
{
    public class FakeCustomersService : FakeEntitiesService<Customer>, ICustomersService
    {
        public IEnumerable<Customer> GetByCity(string city)
        {
            throw new NotImplementedException();
        }

        public override void Remove(int id)
        {
            Customer customer = Get(id);
            customer.IsDeleted = true;

         //   base.Remove(id);
        }
    }
}
