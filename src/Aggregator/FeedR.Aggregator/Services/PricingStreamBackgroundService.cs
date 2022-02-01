using FeedR.Shared.Streaming;

namespace FeedR.Aggregator.Services;

internal sealed class PricingStreamBackgroundService : BackgroundService
{
    private readonly IStreamSubscriber _streamSubscriber;
    public PricingStreamBackgroundService(IStreamSubscriber streamSubscriber)
    {
        _streamSubscriber = streamSubscriber;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await _streamSubscriber.SubscribeAsync<CurrencyPair>("pricing", currencyPair =>
        {
        });
    }

    private record CurrencyPair(string Symbol, decimal Value, long Timestamp);
}
