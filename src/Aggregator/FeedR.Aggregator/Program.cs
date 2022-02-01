using FeedR.Aggregator.Extensions;
using FeedR.Shared.Redis;
using FeedR.Shared.Serialization;
using FeedR.Shared.Streaming;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddStreaming()
    .AddSerialization()
    .AddRedis(builder.Configuration)
    .AddServices();

var app = builder.Build();

app.MapGet("/", () => "FeedR Aggregator");
app.Run();