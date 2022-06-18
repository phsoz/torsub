using TorSub.Domain.Common;

namespace TorSub.Application.Contracts;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}

