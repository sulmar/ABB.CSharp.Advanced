using System;
using System.Threading.Tasks;
using System.Linq;
using ABB.Flisr.SensorClient.Services;

namespace ABB.Flisr.SensorClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            SensorsViewModel sensorsViewModel = new SensorsViewModel(new ESPSensorsService());
            await sensorsViewModel.LoadAsync();


            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }


    public class SensorsViewModel
    {
        private readonly ISensorsService sensorsService;

        public SensorsViewModel(ISensorsService sensorsService)
        {
            this.sensorsService = sensorsService;
        }

        public async Task LoadAsync()
        {
            var measure = await sensorsService.GetAsync();

            Console.WriteLine(measure.Sensors.First().TaskValues.First().Value);
        }
    }
}
