using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using WebApplication;

var host = CreateHostBuilder(args).Build();
await host.InitAsync();
await host.RunAsync();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });