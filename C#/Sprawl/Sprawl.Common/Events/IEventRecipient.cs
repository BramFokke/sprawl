using Sprawl.Common.Extensibility;

namespace Sprawl.Common.Events
{
    public interface IEventRecipient : IService
    {

        void Receive(int message, string payload);

    }
}
