using System;
using System.Threading.Tasks;
using System.Linq;
using ABB.Flisr.SensorClient.Services;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace ABB.Flisr.SensorClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // add package Microsoft.Extensions.DependencyInjection

            var colection = new ServiceCollection()
                    .AddScoped<SensorsViewModel>()
                    .AddSingleton<ISensorsService, ESPSensorsService>();
                  //  .AddHttpClient<ISensorsService, ESPSensorsService>();

            var serviceProvider = colection.BuildServiceProvider();

            SensorsViewModel sensorsViewModel = serviceProvider.GetService<SensorsViewModel>();

            // add package Microsoft.Extensions.Http

        

           sensorsViewModel.LoadAsync();

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

        public void LoadAsync()
        {
            // var measure = await sensorsService.GetAsync();
            //  Console.WriteLine(measure.Sensors.First().TaskValues.First().Value);
            // var x = sensorsService.GetAsync().ToObservable();

            var source = Observable.Interval(TimeSpan.FromSeconds(5))
                 .Select(_ => Observable.FromAsync(t=>sensorsService.GetAsync()))
                 .SelectMany(x=>x);

            source.Subscribe(m => Console.WriteLine(m.Sensors.First().TaskValues.First().Value));

          //  source.Subscribe(m => (x => x.Sensors.First().TaskValues.First().Value));

        }
    }
}
