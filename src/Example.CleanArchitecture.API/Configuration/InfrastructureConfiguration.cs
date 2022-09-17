namespace Example.CleanArchitecture.API.Configuration
{
    public static class InfrastructureConfiguration
    {
        public static WebApplicationBuilder AddInfrastructureServices(this WebApplicationBuilder builder)
        {
            //Add db

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
            builder.Services.AddScoped<ISalesRepository, SalesRepository>();
            return builder;
        }

        public static WebApplication UseInfrastructureServices(this WebApplication app)
        {
            return app;
        }
    }
}
