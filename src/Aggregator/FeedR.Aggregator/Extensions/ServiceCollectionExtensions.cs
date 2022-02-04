using FeedR.Aggregator.Services;

namespace FeedR.Aggregator.Extensions;

internal static class ServiceCollectionExtensions
{
    internal static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services
            .AddHostedService<PricingStreamBackgroundService>();
    }
}
