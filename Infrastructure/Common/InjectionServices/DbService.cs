using Domain;
using Infrastructure.Database;
using Infrastructure.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Common.InjectionServices
{
    public class DbService
    {
        public static void AddDbService(IServiceCollection service, string userConStr, string academyConStr)
        {
            service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(userConStr));

            service.AddDbContext<AcademyDbContext>(options => options.UseLazyLoadingProxies().UseSqlServer(academyConStr));
        }
    }
}
