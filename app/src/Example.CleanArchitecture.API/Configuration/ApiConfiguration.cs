using System.Text.Json.Serialization;

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

            builder.Services.AddControllers()
                            .AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

            builder.Services.AddEndpointsApiExplorer()
                            .AddSwaggerConfiguration();

            builder.Services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            builder.Services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return builder;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseSwaggerConfiguration(provider);

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseMiddleware<ExceptionMiddleware>();

            return app;
        }
    }
}
