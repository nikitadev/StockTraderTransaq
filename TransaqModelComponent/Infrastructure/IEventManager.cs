
namespace TransaqModelComponent.Infrastructure
{
    public interface IEventManager
    {
        void Subscribe(string tagEvent, IEventCallback eventCallback);

        void Unsubscribe(string tagEvent);
    }
}
