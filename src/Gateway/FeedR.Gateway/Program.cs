var builder = WebApplication.CreateBuilder(args);

var yarpConfiguration = builder.Configuration.GetSection("yarp");

builder.Services
    .AddReverseProxy()
    .LoadFromConfig(yarpConfiguration);

var app = builder.Build();

app.MapGet("/", () => "FeedR Gateway");
app.MapReverseProxy();
app.Run();