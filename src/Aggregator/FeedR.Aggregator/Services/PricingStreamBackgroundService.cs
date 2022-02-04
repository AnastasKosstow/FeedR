using FeedR.Shared.Redis.Streaming.Abstractions;

namespace FeedR.Aggregator.Services;

internal sealed class PricingStreamBackgroundService : BackgroundService
{
    private readonly ILogger<PricingStreamBackgroundService> _logger;
    private readonly IStreamSubscriber _streamSubscriber;

    public PricingStreamBackgroundService(
        ILogger<PricingStreamBackgroundService> logger,
        IStreamSubscriber streamSubscriber)
    {
        _logger = logger;
        _streamSubscriber = streamSubscriber;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await _streamSubscriber.SubscribeAsync<CurrencyPair>("pricing", currencyPair =>
        {
            _logger.LogInformation(
                Log(currencyPair.Symbol, 
                    currencyPair.Value, 
                    currencyPair.Timestamp));
        });
    }

    private string Log(string symbol, decimal Value, long Timestamp)
        =>
        $"{symbol}, {Value:F} -> {Timestamp:F}";

    private record CurrencyPair(string Symbol, decimal Value, long Timestamp);
}
