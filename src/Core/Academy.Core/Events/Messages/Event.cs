using MediatR;

namespace Academy.Core.Events.Messages;

public abstract class Event: Message, INotification
{
    public DateTime Timestamp { get; private set; }

    protected Event()
    {
        Timestamp = DateTime.Now;
    }
}