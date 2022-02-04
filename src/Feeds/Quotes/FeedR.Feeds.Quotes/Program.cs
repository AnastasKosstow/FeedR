using FeedR.Feeds.Quotes.Extensions;
using FeedR.Feeds.Quotes.Pricing.Factory;
using FeedR.Feeds.Quotes.Pricing.Services;
using FeedR.Shared.Redis;
using FeedR.Shared.Redis.Streaming;
using FeedR.Shared.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddSerialization()
    .AddRedis(builder.Configuration)
    .AddRedisStreaming()
    .AddServices()
    .AddPricingFactory()
    .AddBackgroundServices();

var app = builder.Build();

app.MapGet("/", () => "FeedR Quotes");

#region PricingBackgroundService
app.MapPost("/pricing/start", async (PricingRequestChannel channel, IPricingRequestFactory pricingFactory) =>
{
    await channel.Requests.Writer.WriteAsync(pricingFactory.StartRequest());
    return "Pricing Background service Started!";
});

app.MapPost("/pricing/stop", async (PricingRequestChannel channel, IPricingRequestFactory pricingFactory) =>
{
    await channel.Requests.Writer.WriteAsync(pricingFactory.StopRequest());
    return "Pricing Background service Stopped!";
});
#endregion

app.Run();
