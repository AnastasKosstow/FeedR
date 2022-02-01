using Microsoft.Extensions.DependencyInjection;

namespace FeedR.Shared.Serialization;

public static class SerializationExtensions
{
    public static IServiceCollection AddSerialization(this IServiceCollection services)
    => services
        .AddSingleton<ISerializer, SystemTextJsonSerializer>();
}



