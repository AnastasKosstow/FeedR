namespace FeedR.Feeds.Quotes.Pricing.Services
{
    internal class PricingBackgroundService : BackgroundService
    {
        private readonly IPricingGenerator _pricingGenerator;

        public PricingBackgroundService(IPricingGenerator pricingGenerator)
            =>
            _pricingGenerator = pricingGenerator;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.Factory.StartNew(() =>
                _pricingGenerator.StartAsync(),
                TaskCreationOptions.LongRunning);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _pricingGenerator.StopAsync();
        }
    }
}
