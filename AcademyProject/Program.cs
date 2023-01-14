using AcademyProject;
using Application;
using Application.Authentication;
using Application.Common.Interfaces;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);
builder.SetAppServices();

var app = builder.Build();
try
{
    await SeedData.Seed(app);
}
catch (Exception ex)
{
   /* var Logger = app.Services.GetRequiredService<ILogger>();
    Logger.Log(LogLevel.Error, ex.Message);*/
}


app.SetAppMiddleWare();
