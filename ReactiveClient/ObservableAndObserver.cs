using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReactiveClient
{
    class ObservableAndObserver
    {
        public static void ColdSourceTest()
        {
            var source = new MySourceObservable();
            var observer = new MyObserver("Marcin");

            using (var subscription = source.Subscribe(observer))
            {

            }

            // subscription.Dispose();
        }
    }

    public class MyObserver : IObserver<float>
    {
        public MyObserver(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public void OnCompleted()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} [{Name}] completed");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} [{Name}] error {error.Message}");
        }

        public void OnNext(float value)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} [{Name}] received {value}");
        }
    }

    public class MySourceObservable : IObservable<float>
    {
        public IDisposable Subscribe(IObserver<float> observer)
        {

            Random random = new Random();

            while (true)
            {
                observer.OnNext((float)random.NextDouble() * 100);

                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            //observer.OnNext(20.32f);
            //observer.OnNext(15.25f);

            //observer.OnCompleted();

            return new EmptyDisposable();
        }

        private class EmptyDisposable : IDisposable
        {
            public void Dispose()
            {
                Console.WriteLine("Dispose!");
            }
        }
    }
}
