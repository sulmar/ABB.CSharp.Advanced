using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABB.Flisr.ConsoleClient
{
    public class LockTests
    {

        private int x = 0;
        readonly object syncLock = new object();

        public void LockTest()
        {
            Task.Run(() => Calculate1());
            Task.Run(() => Calculate2());

        }

        private void Calculate1()
        {

            lock (syncLock)
            {

                while (true)
                {
                
                    x = 100;

                    Thread.Sleep(TimeSpan.FromSeconds(1));

                    Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} 100  {x}");
                }
            }
        }

        private void Calculate2()
        {
            while (true)
            {
                lock (syncLock)
                {
                    x = 50;

                    Thread.Sleep(TimeSpan.FromSeconds(1));

                    Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} 50 {x}");
                }
            }
        }
    }
}
