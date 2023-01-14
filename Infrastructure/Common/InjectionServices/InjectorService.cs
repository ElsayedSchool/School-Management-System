using Application.Authentication;
using Application.Common.Interfaces;
using Application.Common.Interfaces.EntityRepositories;
using FluentValidation.AspNetCore;
using Infrastructure.Database.Repository;
using Infrastructure.Database.UnitOfWork;
using Infrastructure.Infrastructure.Identity;
using Infrastructure.InfrastructureService.JWTToken;
using Infrastructure.InfrastructureService.JWTToken.CreateToken;
using Microsoft.Extensions.DependencyInjection;
using Northwind.Application.Common.Interfaces;
using Northwind.Common;
using Northwind.Infrastructure;

namespace Infrastructure.Common.InjectionServices
{
    public class InjectorService
    {
        public static void AddInjectorService(IServiceCollection services)
        {
            services.AddScoped<IUserManagerService, UserManagerService>();
            services.AddScoped<IApplicationRepo, ApplicationRepo>();
            services.AddScoped<IUserSignInManagerService, UserSignInManagerService>();
            services.AddScoped<IJWTToken, JWTToken>();
            services.AddScoped<ICreateToken, CreateToken>();

            services.AddTransient<IDateTime, MachineDateTime>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddCenterCommandValidator>());
        }

        
    }
}
