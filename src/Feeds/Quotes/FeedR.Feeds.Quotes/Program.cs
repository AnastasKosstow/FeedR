using FeedR.Feeds.Quotes.Extensions;
using FeedR.Feeds.Quotes.Pricing.Factory;
using FeedR.Feeds.Quotes.Pricing.Services;
using FeedR.Shared.Redis;
using FeedR.Shared.Serialization;
using FeedR.Shared.Streaming;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddStreaming()
    .AddSerialization()
    .AddRedis(builder.Configuration)
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
