using Sprawl.Common.Extensibility;

namespace Sprawl.Common.Events
{
    public interface IEventSender : IService
    {

        void Send(IEventRecipient recipient, int message, string payload);

    }
}
