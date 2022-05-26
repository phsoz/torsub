using WhatWatch.Domain.Common;

namespace WhatWatch.Application.Contracts;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}

