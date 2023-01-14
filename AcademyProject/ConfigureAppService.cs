using AcademyProject.Services;
using Application;
using Application.Authentication;
using Application.Common.Interfaces;
using FluentValidation.AspNetCore;
using Infrastructure;

namespace AcademyProject
{
    public static class ConfigureAppService
    {
        public static WebApplicationBuilder SetAppServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.

            builder.Services.AddControllers();
               //.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<SignUpCommandValidator>());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            


            // Inject all Dependencies in All Three Layers
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration, builder.Environment);
            builder.Services.ConfigureApiBehavior();

            // Add Current User injection
            /*builder.Services.AddHealthChecks()
                            .AddDbContextCheck<ApplicationDbContext>();*/

            builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
            builder.Services.AddCors(c => c.AddPolicy("mypolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
            }));
            builder.Services.AddHttpContextAccessor();
            return builder;
        }
    }
}
