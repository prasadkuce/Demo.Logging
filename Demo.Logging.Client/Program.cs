// See https://aka.ms/new-console-template for more information
using Demo.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");
var logger = new DefaultLoggerFactory().GetLogger();
logger.Log("Test", Severity.Information);

var logger1 = new FileLoggerFactory().GetLogger();
logger1.Log("test from filer logger", Severity.Warning);

using var host = CreateHostBuilder(args).Build();
using var serviceScope = host.Services.CreateScope();
var provider = serviceScope.ServiceProvider;
var logger2 = provider.GetRequiredService<ILoggerAbstractFactory>().GetLogger();
logger2.Log("test from filer logger via DI", Severity.Warning);

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
            services.AddTransient<ILoggerAbstractFactory, FileLoggerFactory>());
}
