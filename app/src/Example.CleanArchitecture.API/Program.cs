var builder = WebApplication.CreateBuilder(args);

builder.AddApiServices()
       .AddApplicationServices()
       .AddInfrastructureServices();

var app = builder.Build();

app.UseApiServices()
   .UseApplicationServices()
   .UseInfrastructureServices();

app.Run();
