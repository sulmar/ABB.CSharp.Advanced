using ABB.Flisr.FakeServices.Fakers;
using ABB.Flisr.IServices;
using ABB.Flisr.Models;
using System.Linq;
using System.Text;

namespace ABB.Flisr.FakeServices
{

    public class FakeUsersService : FakeEntitiesService<User>, IUsersService
    {
        private UserFaker userFaker;

        public FakeUsersService()
        {
            userFaker = new UserFaker();

            this.entities = userFaker.Generate(100);
        }
    }
}
