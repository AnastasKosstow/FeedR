using FeedR.Feeds.Quotes.Pricing.Requests;

namespace FeedR.Feeds.Quotes.Pricing.Factory;

internal abstract class PricingRequestFactoryBase
{
    protected IDictionary<string, Func<IPricingRequest>> Requests = CreateRequestMap();

    private static IDictionary<string, Func<IPricingRequest>> CreateRequestMap()
    {
        return new Dictionary<string, Func<IPricingRequest>>()
            {
                { nameof(StartPricing), () => new StartPricing() },
                { nameof(StopPricing), () => new StopPricing() },
            };
    }
}
