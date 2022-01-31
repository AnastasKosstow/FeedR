using FeedR.Feeds.Quotes.Extensions;
using FeedR.Feeds.Quotes.Pricing.Factory;
using FeedR.Feeds.Quotes.Pricing.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddServices()
    .AddPricingFactory()
    .AddBackgroundServices();

var app = builder.Build();

app.MapGet("/", () => "FeedR Quotes");

#region PricingBackgroundService
app.MapPost("/pricing/start", async (PricingRequestChannel channel, IPricingRequestFactory pricingFactory) =>
{
    await channel.Requests.Writer.WriteAsync(pricingFactory.StartRequest());
    return Results.Ok;
});

app.MapPost("/pricing/stop", async (PricingRequestChannel channel, IPricingRequestFactory pricingFactory) =>
{
    await channel.Requests.Writer.WriteAsync(pricingFactory.StopRequest());
    return Results.Ok;
});
#endregion

app.Run();
