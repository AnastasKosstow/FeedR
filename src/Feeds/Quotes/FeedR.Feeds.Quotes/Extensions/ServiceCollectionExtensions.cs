using FeedR.Feeds.Quotes.Pricing.Services;

namespace FeedR.Feeds.Quotes.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddSingleton<IPricingGenerator, PricingGenerator>();
    }

    internal static IServiceCollection AddBackgroundServices(this IServiceCollection services)
    {
        return services.AddHostedService<PricingBackgroundService>();
    }
}
