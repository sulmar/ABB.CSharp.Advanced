using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ReactiveClient
{
    class SubjectTest
    {

        public static void CPUMonitorTest()
        {
            var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            var source = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(t => cpuCounter.NextValue());

            source.Subscribe(new MyObserver("Marcin"));

        }

        public static void IntervalTest()
        {
            Random random = new Random();

            var source = Observable.Interval(TimeSpan.FromSeconds(1))
                .Select(t => (float) random.NextDouble() * 100);

            source.Where(v=>v > 50).Subscribe(new MyObserver("Marcin"));

        }

        public static void Test()
        {
            var source = new Subject<float>();

            source.OnNext(10.5f);
            source.OnNext(25.4f);

            var subscription1 = source.Subscribe(new MyObserver("Marcin"));

            source.OnNext(77.5f);
            source.OnNext(66.4f);

            source
                .Where(value => value > 50)               
                .Subscribe(new MyObserver("Michal"));

            source.Subscribe(value => Console.WriteLine($"{value}"));

            source.OnNext(10.44f);
            source.OnNext(48f);

            subscription1.Dispose();

            source.OnNext(99f);


            source.OnCompleted();

          



        }
    }
}
