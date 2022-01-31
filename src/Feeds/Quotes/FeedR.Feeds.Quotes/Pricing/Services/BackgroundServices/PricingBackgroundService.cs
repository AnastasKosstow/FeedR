using FeedR.Feeds.Quotes.Pricing.Requests;

namespace FeedR.Feeds.Quotes.Pricing.Services
{
    internal class PricingBackgroundService : BackgroundService
    {
        private readonly ILogger<PricingBackgroundService> _logger;
        private readonly IPricingGenerator _pricingGenerator;
        private readonly PricingRequestChannel _requestChannel;

        public PricingBackgroundService(ILogger<PricingBackgroundService> logger, IPricingGenerator pricingGenerator, PricingRequestChannel requestChannel)
        {
            _logger = logger;
            _pricingGenerator = pricingGenerator;
            _requestChannel = requestChannel;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await foreach (IPricingRequest request in _requestChannel.Requests.Reader.ReadAllAsync(cancellationToken))
            {
                if (request is StartPricing)
                {
                    await Task.Factory.StartNew(() => _pricingGenerator.StartAsync(), TaskCreationOptions.LongRunning);
                }
                else if (request is StopPricing)
                {
                    await _pricingGenerator.StopAsync();
                }
                else
                {
                    _logger.LogInformation($"No Request found!");
                }
            }
        }
    }
}
