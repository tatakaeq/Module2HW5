using System;
using Microsoft.Extensions.DependencyInjection;
using Module2HW5.Services;
using Module2HW5.Services.Abstractions;

namespace Module2HW5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<ILoger, Loger>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<IConfigService, ConfigService>()
                .AddTransient<IWriterService, WriterService>()
                .AddTransient<Starter>()
                .BuildServiceProvider();

            var start = serviceProvider.GetService<Starter>();
            start?.Run();
        }
    }
}