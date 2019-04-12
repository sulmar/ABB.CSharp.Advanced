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
        // private readonly HttpClient client;

        //public ESPSensorsService()
        //    : this(new HttpClient())
        //{

        //}

        //public ESPSensorsService(HttpClient client)
        //{
        //    this.client = client;
        //}

        public async Task<Rootobject> GetAsync()
        {
            string baseuri = "http://192.168.43.229";

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseuri);

                var response = await client.GetStringAsync("/json?view=sensorupdate");

                var measure = JsonConvert.DeserializeObject<Rootobject>(response);

                return measure;
            }

        }
    }
}
