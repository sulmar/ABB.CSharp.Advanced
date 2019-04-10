using ABB.Flisr.FakeServices;
using ABB.Flisr.FakeServices.Fakers;
using ABB.Flisr.IServices;
using ABB.Flisr.Models;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABB.Flisr.NetworkClient
{
    class Program
    {
        static void Main(string[] args)
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

            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();
          
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
