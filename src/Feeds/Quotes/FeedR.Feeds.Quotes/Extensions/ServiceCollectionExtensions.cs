using FeedR.Feeds.Quotes.Pricing.Factory;
using FeedR.Feeds.Quotes.Pricing.Services;

namespace FeedR.Feeds.Quotes.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services.AddSingleton<IPricingGenerator, PricingGenerator>();
    }

    internal static IServiceCollection AddPricingFactory(this IServiceCollection services)
    {
        return services.AddSingleton<IPricingRequestFactory, PricingRequestFactory>();
    }

    internal static IServiceCollection AddBackgroundServices(this IServiceCollection services)
    {
        return services.AddHostedService<PricingBackgroundService>();
    }
}
