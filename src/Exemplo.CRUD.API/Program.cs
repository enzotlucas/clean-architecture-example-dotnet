var app = WebApplication.CreateBuilder(args)
                        .ConfigureServices()
                        .Build();

app.UseServices()
    .Run();
