using ABB.Flisr.FakeServices.Fakers;
using ABB.Flisr.IServices;
using ABB.Flisr.Models;
using System.Linq;
using System.Text;

namespace ABB.Flisr.FakeServices
{

    public class FakeUsersService : FakeEntitiesService<User>, IUsersService
    {
        private readonly UserFaker userFaker;

        public FakeUsersService(UserFaker userFaker, int count = 10)
        {
            this.userFaker = userFaker;

            this.entities = userFaker.Generate(count);
        }
    }
}
