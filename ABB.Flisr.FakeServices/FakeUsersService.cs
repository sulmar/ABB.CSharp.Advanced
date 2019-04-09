using ABB.Flisr.IServices;
using ABB.Flisr.Models;
using System.Linq;
using System.Text;

namespace ABB.Flisr.FakeServices
{

    public class FakeUsersService : FakeEntitiesService<User>, IUsersService
    {
      
    }
}
