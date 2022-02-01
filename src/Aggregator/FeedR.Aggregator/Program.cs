using FeedR.Aggregator.Extensions;
using FeedR.Shared.Redis;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddRedis(builder.Configuration)
    .AddServices();

var app = builder.Build();

app.MapGet("/", () => "FeedR Aggregator");
app.Run();