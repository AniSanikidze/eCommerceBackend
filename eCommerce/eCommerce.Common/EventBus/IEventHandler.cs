using eCommerce.Common.EventBus.Events;

namespace eCommerce.Common.EventBus
{
    public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : IntegrationEvent
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
