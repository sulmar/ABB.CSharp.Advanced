using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABB.Flisr.ConsoleClient
{
    class ConcurrentCollectionTests
    {

        public static void BlockingCollectionTest()
        {
            BlockingCollection<int> measures = new BlockingCollection<int>();

            Task.Run(() => Produce(measures));
            Task.Run(() => Consume(measures));

            Console.WriteLine("Press any key to complete");

            Console.ReadKey();

            measures.CompleteAdding();
        }

        private static void Produce(BlockingCollection<int> measures)
        {
            int measure = 0;

            Random random = new Random();
           
            while (!measures.IsAddingCompleted)
            {
                measure = random.Next(0, 100);

                measures.Add(measure);

                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} sent: {measure}");

                Thread.Sleep(TimeSpan.FromSeconds(1));         
            }
        }

        private static void Consume(BlockingCollection<int> measures)
        {
            foreach (var measure in measures.GetConsumingEnumerable())
            {
                Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} received: {measure}");

                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
        }
    }
}
