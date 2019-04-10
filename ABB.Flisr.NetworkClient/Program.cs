using ABB.Flisr.FakeServices;
using ABB.Flisr.FakeServices.Fakers;
using ABB.Flisr.IServices;
using ABB.Flisr.Models;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABB.Flisr.NetworkClient
{
    class Program
    {
        static void Send(string message)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} sending...");

            Thread.Sleep(TimeSpan.FromSeconds(3));

            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
          //  TaskList();

            //  DependencyInjectionTest();

            //  SyncTest();

            //  AsyncTest();

            // AsyncAwaitTest();

            // AsyncAwaitProgressTest();

// AsyncAwaitProgressCancellationTest();

            //  ThreadTest();

            // ThreadPoolTest();

            //for (int i = 0; i < 100; i++)
            //{
            //    Task.Run(()=>Calculate());
            //}

            // ParallelTasksTest();

            // task list

            // TaskList();

            Console.WriteLine("Finished.");







            //Thread thread2 = new Thread(Calculate);
            //thread2.Start();

            //Thread thread3 = new Thread(Calculate);
            //thread3.Start();


            //  Calculate();

            DownloadAsyncTest();

       //     DownloadTest();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();

        }


        private static void DownloadTest()
        {
            WebClient client = new WebClient();
            string url = "http://www.abb.com";

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} downloading...");

            string content = client.DownloadString(url);

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} downloaded {content}");     
        }

        private static async Task DownloadAsyncTest()
        {
            WebClient client = new WebClient();
            string url = "http://www.abb.com";

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} downloading...");

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(0.1));
            CancellationToken cancellationToken = cancellationTokenSource.Token;         
            
            cancellationToken.Register(()=>client.CancelAsync());

            await Task.Delay(TimeSpan.FromSeconds(1), cancellationToken);

            string content = await client.DownloadStringTaskAsync(new Uri(url));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} downloaded {content}");
        }




        private static void AsyncTest()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId}");

            CalculateAsync(100)
                .ContinueWith(t => Calculate(t.Result))
                    .ContinueWith(t => Send($"Total {t.Result}"));      
        }

        private static void SyncTest()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId}");

            decimal amount = Calculate(100);
            amount = Calculate(amount);
            Send($"Total {amount}");
        }

        private static async Task AsyncAwaitTest()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId}");

            decimal amount = await CalculateAsync(100).ConfigureAwait(false);
            amount = await CalculateAsync(amount);
            await SendAsync($"Total {amount}");
        }


        private static async void AsyncAwaitProgressTest()
        {
            IProgress<int> progress = new Progress<int>(i => Console.Write($"#{Thread.CurrentThread.ManagedThreadId}"));
            
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId}");

            decimal amount = await CalculateAsync(100,  null, progress).ConfigureAwait(false);
            amount = await CalculateAsync(amount, null, progress);
            await SendAsync($"Total {amount}");
        }


        private static async void AsyncAwaitProgressCancellationTest()
        {
            IProgress<int> progress = new Progress<int>(i => Console.Write($"#{Thread.CurrentThread.ManagedThreadId}"));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId}");

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            CancellationToken cancellationToken = cancellationTokenSource.Token;

         //   CancellationTokenSource cancellationTokenSource2 = new CancellationTokenSource();

        //    cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(3));

            try
            {
                decimal amount = await CalculateAsync(100, cancellationToken, progress).ConfigureAwait(false);
                amount = await CalculateAsync(amount, cancellationToken, progress);
                await SendAsync($"Total {amount}");
            }
            catch(OperationCanceledException e)
            {
                Console.WriteLine("Calculate cancelled.");
            }

        }

        private static Task SendAsync(string message)
        {
            return Task.Run(() => Send(message));
        }

        private static Task<decimal> CalculateAsync(decimal amount,
            CancellationToken? cancellationToken = null,
            IProgress<int> progress = null)
        {
            return Task.Run(() => Calculate(amount, cancellationToken, progress));
        }

        private static void ParallelTasksTest()
        {
            Task<decimal> task1 = Task.Run<decimal>(() => Calculate(100));

            Task<decimal> task2 = Task.Run<decimal>(() => Calculate(200));

            Task.WaitAll(task1, task2);

            decimal total = task1.Result + task2.Result;

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Total {total}");
        }

        private static void TaskList()
        {
            ICollection<Task> tasks = new List<Task>();

            Task task3 = new Task(() => Send());
            Task<decimal> task4 = new Task<decimal>(() => Calculate(100));
            Task<decimal> task5 = new Task<decimal>(() => Calculate(200));

            tasks.Add(task3);
            tasks.Add(task4);
            tasks.Add(task5);

            foreach (var task in tasks)
            {
                task.Start();
            }

            Task.WhenAll(tasks).Wait();
           
            var total = tasks.OfType<Task<decimal>>().Sum(t => t.Result);

        }

        private static void ThreadPoolTest()
        {
            for (int i = 0; i < 100; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Calculate2));
            }
        }

        private static void ThreadTest()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread thread1 = new Thread(Send);
                thread1.Start();

                Thread.Sleep(TimeSpan.FromSeconds(1));

            }
        }

        private static void Calculate2(object callback)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Calculating...");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Calculated.");
        }


        private static decimal Calculate(decimal amount,
            CancellationToken? cancellationToken = null,
            IProgress<int> progress = null)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Calculating...");

            for (int i = 0; i < 10; i++)
            {
                 cancellationToken?.ThrowIfCancellationRequested();

                //if (cancellationToken.Value.IsCancellationRequested)
                //{

                //}

                Thread.Sleep(TimeSpan.FromSeconds(0.5));

                progress?.Report(i);
            

            }
           
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Calculated.");

            return amount + 10;
        }

        private static void Send()
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Sending...");

            Thread.Sleep(TimeSpan.FromSeconds(5));

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Sent.");
        }

        private static void DependencyInjectionTest()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<FakeNetworksService>().As<INetworksService>();
            containerBuilder.RegisterType<FakeUsersService>().As<IUsersService>().SingleInstance();


            containerBuilder.RegisterType<NetworkViewModel>();
            containerBuilder.RegisterType<UsersViewModel>();
            containerBuilder.RegisterType<UserFaker>();


            IContainer container = containerBuilder.Build();

            // NetworkViewModel networkViewModel = new NetworkViewModel(new FakeNetworksService());

            NetworkViewModel networkViewModel = container.Resolve<NetworkViewModel>();
            UsersViewModel usersViewModel = container.Resolve<UsersViewModel>();

            networkViewModel.Load();
        }
    }

    public class UsersViewModel
    {
        private readonly IUsersService usersService;

        public UsersViewModel(IUsersService usersService)
        {
            this.usersService = usersService;
        }
    }

    public class NetworkViewModel
    {
        public Network Network { get; set; }

        private readonly INetworksService networksService;
        private readonly IUsersService usersService;

        public NetworkViewModel()
            : this(new FakeNetworksService(), new FakeUsersService(new UserFaker()) )
        {

        }

        public NetworkViewModel(INetworksService networksService, IUsersService usersService)
        {
            this.networksService = networksService;
            this.usersService = usersService;
        }

        public void Load()
        {
            var networkId = 1;     
 
            this.Network  = networksService.Get(networkId);
        }

        public void Calculate()
        {

        }
    }
}
