using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Installers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder => { builder.RegisterModule(new AutofacBusinessModule()); })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}