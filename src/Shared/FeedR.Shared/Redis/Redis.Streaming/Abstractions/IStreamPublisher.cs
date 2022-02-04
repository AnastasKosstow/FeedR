
namespace FeedR.Shared.Redis.Streaming.Abstractions;

public interface IStreamPublisher
{
    Task PublishAsync<T>(string topic, T data) where T : class; 
}

