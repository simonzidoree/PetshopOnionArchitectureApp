using Microsoft.Extensions.DependencyInjection;
using Petshop.Core.ApplicationService;
using Petshop.Core.ApplicationService.Services;
using Petshop.Core.DomainService;
using Petshop.Infrastructure.Data;
using Petshop.Infrastructure.Data.Repositories;
using System;

namespace Petshop.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FakeDB.InitData();
            Console.WriteLine("Pets initiated...");
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petService = serviceProvider.GetRequiredService<IPetService>();
            new Printer(petService);

            Console.ReadLine();
        }
    }
}
