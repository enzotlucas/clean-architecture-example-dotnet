namespace Example.CleanArchitecture.API.Configuration
{
    public static class ApiConfiguration
    {
        public static WebApplicationBuilder AddApiServices(this WebApplicationBuilder builder)
        {
            builder.Configuration
                   .SetBasePath(builder.Environment.ContentRootPath)
                   .AddJsonFile("appsettings.json", true, true)
                   .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                   .AddEnvironmentVariables();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            return builder;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}
