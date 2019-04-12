using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReactiveClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //  ObservableAndObserver.ColdSourceTest();

            // SubjectTest.Test();
            SubjectTest.CPUMonitorTest();   


          //  SubjectTest.IntervalTest();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();


        }

      
    }

   


}
