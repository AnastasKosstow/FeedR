using FeedR.Feeds.Quotes.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddServices()
    .AddBackgroundServices();

var app = builder.Build();

app.MapGet("/", () => "FeedR Quotes");
app.Run();
