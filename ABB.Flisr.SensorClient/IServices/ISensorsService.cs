using ABB.Flisr.SensorClient.Models;
using System.Threading.Tasks;

namespace ABB.Flisr.SensorClient
{
    public interface ISensorsService
    {
        Task<Rootobject> GetAsync();
    }
}
