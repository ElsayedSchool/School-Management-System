using AcademyProject.MiddleWares;

namespace AcademyProject
{
    public static class ConfigureAppMiddleware
    {
        public static WebApplication SetAppMiddleWare(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCustomExceptionHandler();
            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCors("mypolicy");

            app.UseAuthentication();

            //app.UseIdentityServer();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
            return app;
        }
    }
}
