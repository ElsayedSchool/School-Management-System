using Infrastructure.Common.InjectionServices;
using Infrastructure.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructure(this IServiceCollection service, ConfigurationManager configuration, IWebHostEnvironment environment)
        {
            var academyConnectionStr = configuration.GetConnectionString("Default");
            var userConnectionStr = configuration.GetConnectionString("Users");

            InjectorService.AddInjectorService(service);

            DbService.AddDbService(service, userConnectionStr, academyConnectionStr);

            IdentityService.AddIdentityService(service);

            TokenService.AddAuthentication(service, configuration);

            ConfigurationService.AddConfigurationService(service, configuration);

            Loggerservice.AddLoggingService(service);

        }
    }
}
