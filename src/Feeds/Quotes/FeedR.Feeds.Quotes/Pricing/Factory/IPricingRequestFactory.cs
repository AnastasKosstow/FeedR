using FeedR.Feeds.Quotes.Pricing.Requests;

namespace FeedR.Feeds.Quotes.Pricing.Factory;

internal interface IPricingRequestFactory
{
    IPricingRequest StartRequest();
    IPricingRequest StopRequest();
}
