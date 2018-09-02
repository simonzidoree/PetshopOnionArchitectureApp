using Microsoft.Extensions.DependencyInjection;
using Petshop.Core.ApplicationService;
using Petshop.Core.ApplicationService.Services;
using Petshop.Core.DomainService;
using Petshop.Infrastructure.Data;
using Petshop.Infrastructure.Data.Repositories;

namespace Petshop.ConsoleApp
{
    class Program
    {
        #region Main
        static void Main(string[] args)
        {
            FakeDB.InitData();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.StartUI();
        }
        #endregion
    }
}
