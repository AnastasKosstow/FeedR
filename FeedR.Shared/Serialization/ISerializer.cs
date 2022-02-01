
namespace FeedR.Shared.Serialization;

public interface ISerializer
{
    string Serialize<T>(T value) where T : class;
    T? Deserealize<T>(string value) where T : class;
}
