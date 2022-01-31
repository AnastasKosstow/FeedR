using FeedR.Feeds.Quotes.Pricing.Requests;

namespace FeedR.Feeds.Quotes.Pricing.Factory;

internal sealed class PricingRequestFactory : PricingRequestFactoryBase, IPricingRequestFactory
{
    public IPricingRequest StartRequest()
        => 
        FindProvider(nameof(StartPricing));


    public IPricingRequest StopRequest()
        => 
        FindProvider(nameof(StopPricing));

    #region PRIVATE
    private IPricingRequest FindProvider(string requestName)
    {
        Requests.TryGetValue(requestName, out var requestProvider);
        if (requestProvider is null)
            throw new NotSupportedException("No Request found!");

        return requestProvider();
    }
    #endregion
}
