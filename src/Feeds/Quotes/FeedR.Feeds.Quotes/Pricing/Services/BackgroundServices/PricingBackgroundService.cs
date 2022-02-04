using FeedR.Feeds.Quotes.Pricing.Requests;
using FeedR.Shared.Streaming;

namespace FeedR.Feeds.Quotes.Pricing.Services;

internal class PricingBackgroundService : BackgroundService
{
    private int _runningStatus;
    private readonly IPricingGenerator _pricingGenerator;
    private readonly IStreamPublisher _streamPublisher;
    private readonly PricingRequestChannel _requestChannel;

    public PricingBackgroundService(
        IPricingGenerator pricingGenerator, 
        IStreamPublisher streamPublisher, 
        PricingRequestChannel requestChannel)
    {
        _pricingGenerator = pricingGenerator;
        _streamPublisher = streamPublisher;
        _requestChannel = requestChannel;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await foreach (IPricingRequest request in _requestChannel.Requests.Reader.ReadAllAsync(cancellationToken))
        {
            if (request is StartPricing)
            {
                await StartGeneratorAsync();
            }
            else if (request is StopPricing)
            {
                await StopGeneratorAsync();
            }
            else
            {
                // throw
            }
        }
    }

    private async Task StartGeneratorAsync()
    {
        if (Interlocked.Exchange(ref _runningStatus, 1) == 1)
        {
            return;
        }

        await foreach (var currencyPair in _pricingGenerator.StartAsync())
        {
            await _streamPublisher.PublishAsync("pricing", currencyPair);
        }
    }

    private async Task StopGeneratorAsync()
    {
        if (Interlocked.Exchange(ref _runningStatus, 0) == 0)
        {
            return;
        }
        await _pricingGenerator.StopAsync();
    }
}
