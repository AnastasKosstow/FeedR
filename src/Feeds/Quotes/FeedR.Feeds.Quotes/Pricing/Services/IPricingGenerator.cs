namespace FeedR.Feeds.Quotes.Pricing.Services;

public interface IPricingGenerator
{
    Task StartAsync();
    Task StopAsync();
}

