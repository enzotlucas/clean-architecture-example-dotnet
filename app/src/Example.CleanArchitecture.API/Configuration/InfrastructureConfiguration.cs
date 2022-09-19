namespace Example.CleanArchitecture.API.Configuration
{
    public static class InfrastructureConfiguration
    {
        public static WebApplicationBuilder AddInfrastructureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ApplicationContext>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
            builder.Services.AddScoped<ISalesRepository, SalesRepository>();

            builder.Services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            return builder;
        }

        public static WebApplication UseInfrastructureServices(this WebApplication app)
        {
            return app;
        }
    }
}
