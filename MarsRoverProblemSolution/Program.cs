using MarsRoverMain.Repository.Invoker;
using MarsRoverMain.Repository.Provider;
using MarsRoverMain.Service;
using MarsRoverMain.Service.Provider;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRoverMain
{
    public static class Program
    {
        public static void Main()
        {
            var maxPoints = Console.ReadLine().Split(' ');
            var currentLocation = Console.ReadLine().Split(' ');
            var movement = Console.ReadLine();

            var services = new ServiceCollection();
            services.AddSingleton<IMarsRoverMainService, MarsRoverMainService>();
            services.AddSingleton<Invoker, ExecuteAction>();
            var _serviceProvider = services.BuildServiceProvider(true);
            var _MarsRoverMainService = _serviceProvider.GetService<IMarsRoverMainService>();
            var _invoker = _serviceProvider.GetService<Invoker>();

            var coordinates = _MarsRoverMainService.MoveRoverSync(maxPoints, currentLocation, movement, _invoker);
            if (coordinates != null)
                Console.WriteLine(coordinates.X + " " + coordinates.Y + " " + coordinates.Dir);
            else
                Console.WriteLine("Bad Request");

            DisposeServices(_serviceProvider);
        }

        /// <summary>
        /// dispose services
        /// </summary>
        /// <param name="_serviceProvider"></param>
        private static void DisposeServices(ServiceProvider _serviceProvider)
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable disposable)
            {
                (disposable).Dispose();
            }
        }
    }
}
