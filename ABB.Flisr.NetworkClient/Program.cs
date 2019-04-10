using ABB.Flisr.FakeServices;
using ABB.Flisr.FakeServices.Fakers;
using ABB.Flisr.IServices;
using ABB.Flisr.Models;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABB.Flisr.NetworkClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //  DependencyInjectionTest();

            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId}");

            //  ThreadTest();

            // ThreadPoolTest();

            //for (int i = 0; i < 100; i++)
            //{
            //    Task.Run(()=>Calculate());
            //}

 //           TasksTest();

            // task list

            // TaskList();

            Console.WriteLine("Finished.");







            //Thread thread2 = new Thread(Calculate);
            //thread2.Start();

            //Thread thread3 = new Thread(Calculate);
            //thread3.Start();


            //  Calculate();

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();

        }

        private static void TasksTest()
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

            tasks.Add(task3);
            tasks.Add(task4);

            foreach (var task in tasks)
            {
                task.Start();
            }

            Task.WhenAll(tasks).Wait();
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

        private static decimal Calculate(decimal amount)
        {
            Console.WriteLine($"#{Thread.CurrentThread.ManagedThreadId} Calculating...");

            Thread.Sleep(TimeSpan.FromSeconds(5));

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
