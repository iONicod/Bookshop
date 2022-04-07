using Microsoft.Extensions.DependencyInjection;
using Bookshop.Core.Application_Service;
using Bookshop.Core.Application_Service.Service;
using Bookshop.Core.Domain_Service;
using Bookshop.Infrastructure.Data;
using System;

namespace Bookshop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IBookRepository, BookRepository>();
            serviceCollection.AddScoped<IServiceImpl, Impl>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();

            printer.StartUI();
        }
    }
}
