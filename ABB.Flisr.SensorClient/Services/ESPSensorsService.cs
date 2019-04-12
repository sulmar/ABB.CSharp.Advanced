using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ABB.Flisr.SensorClient.Models;
using Newtonsoft.Json;

namespace ABB.Flisr.SensorClient.Services
{
    public class ESPSensorsService : ISensorsService
    {


        public async Task<Rootobject> GetAsync()
        {
            string baseuri = "http://192.168.43.229";
            
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseuri);

                var response = await client.GetStringAsync("/json?view=sensorupdate");

                var measure = JsonConvert.DeserializeObject<Rootobject>(response);

                return measure;

            }

            throw new NotImplementedException();
        }
    }
}
