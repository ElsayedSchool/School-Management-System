using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Common.InjectionServices
{
    public static class Loggerservice
    {
        public static void AddLoggingService(this IServiceCollection service)
        {
            service.AddLogging();
        }
    }
}
