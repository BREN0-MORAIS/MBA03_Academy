using Academy.Core.Events.Messages;

namespace Academy.Core.Interfaces;

public interface IMediatrHandler
{
    Task PublicarEvento<T>(T evento) where T : Event;
}
