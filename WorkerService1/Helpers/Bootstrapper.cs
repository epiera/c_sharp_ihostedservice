using Gam_Api.Client.Interfaces;
using Gam_Api.Client.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkerService1.ApiServices.Interfaces;
using WorkerService1.ApiServices.Services;
using WorkerService1.AppServices.Interfaces;
using WorkerService1.AppServices.Services;
using WorkerService1.Workers;

namespace WorkerService1.Helpers
{
    public static class Bootstrapper
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            IConfigurationRoot configuration; configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", false)
               .Build();

            services.Configure<AppSettingsConfiguration>(configuration.GetSection("AplicationSettings"));


            services.AddHostedService<ExcelReaderBackgroundService>();

            AddApplicationServices(services);
            AddApiServices(services);

            AddHttpClientServices(services, configuration);
            services.AddScoped<IExcelReaderWorker, ExcelReaderWorker>();

        }

        private static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ITransportAppService, TransportAppService>();
        }

        private static void AddApiServices(this IServiceCollection services)
        {
            services.AddScoped<ITransportGamApiService, TransportGamApiService>();
        }

        private static void AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
        {
            var uri = configuration.GetSection("AplicationSettings").GetSection("GamApiUri").Value;
            var token = configuration.GetSection("AplicationSettings").GetSection("GamApiToken").Value;

            services.AddHttpClient<ITransportApiService, TransportApiService>(c =>
            {
                c.BaseAddress = new Uri(uri);
                c.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", token);
            });
        }
    }
}
