using Exemplo.CRUD.API.Configurations.Middlewares;
using Exemplo.CRUD.Application.Queries.GetById;

namespace Exemplo.CRUD.API.Configurations
{
    public static class ApplicationConfiguration
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Configuration
                   .SetBasePath(builder.Environment.ContentRootPath)
                   .AddJsonFile("appsettings.json", true, true)
                   .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
                   .AddEnvironmentVariables();

            builder.Logging.ClearProviders();

            builder.Logging.AddConsole();

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddSingleton<ProductContext>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();

            builder.Services.AddMediatR(typeof(CreateProduct), 
                                        typeof(DeleteProduct), 
                                        typeof(GetById), 
                                        typeof(GetAllProducts));

            return builder;
        }

        public static WebApplication UseServices(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseMiddleware(typeof(ExceptionMiddleware));

            return app;
        }
    }
}
