namespace Example.CleanArchitecture.API.Configuration
{
    public static class ApplicationConfiguration
    {
        public static WebApplicationBuilder AddApplicationServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(typeof(CreateProductCommand));

            builder.Services.AddAutoMapper(typeof(ProductProfile));

            builder.Services.AddScoped<IProductService, ProductService>();

            return builder;
        }

        public static WebApplication UseApplicationServices(this WebApplication app)
        {
            return app;
        }
    }
}
