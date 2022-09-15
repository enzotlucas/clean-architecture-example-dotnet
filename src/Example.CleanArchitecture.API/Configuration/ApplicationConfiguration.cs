namespace Example.CleanArchitecture.API.Configuration
{
    public static class ApplicationConfiguration
    {
        public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
        {
            return builder;
        }

        public static WebApplication UseApplicationServices(this WebApplication app)
        {
            return app;
        }
    }
}
