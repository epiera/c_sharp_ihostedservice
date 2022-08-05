using WorkerService1;
using WorkerService1.Helpers;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostCxt, services) =>
    {
        services.AddDependencyInjection();
    })
    .Build();

await host.RunAsync();
