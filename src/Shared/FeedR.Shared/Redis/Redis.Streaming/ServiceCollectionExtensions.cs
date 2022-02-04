using FeedR.Shared.Redis.Streaming.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace FeedR.Shared.Redis.Streaming;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRedisStreaming(this IServiceCollection services)
    => services
        .AddSingleton<IStreamPublisher, RedisStreamPublisher>()
        .AddSingleton<IStreamSubscriber, RedisStreamSubscriber>();
}