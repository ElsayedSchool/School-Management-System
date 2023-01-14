﻿using Application.Common.Models;
using Application.System.Command;
using Domain.Entities;
using Infrastructure.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Infrastructure.Database
{
    public class SeedData
    {

        public static async Task Seed(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;
           
            try
            {
                var academyDbConetxt = services.GetRequiredService<AcademyDbContext>();
                await academyDbConetxt.Database.MigrateAsync();

                var identityDbContext = services.GetRequiredService<ApplicationDbContext>();
                await identityDbContext.Database.MigrateAsync();

                var mediator = services.GetRequiredService<IMediator>();
                await mediator.Send(new DataSeederCommand(), CancellationToken.None);
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger>();
                logger.LogError(ex, "an error occurred during migration");
            }
        }
    }
}
