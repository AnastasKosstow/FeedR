
namespace FeedR.Shared.Redis.Streaming.Abstractions;

public interface IStreamSubscriber
{
    Task SubscribeAsync<T>(string topic, Action<T> handler) where T : class;
}
