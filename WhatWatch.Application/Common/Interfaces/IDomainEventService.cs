using WhatWatch.Domain.Common;

namespace WhatWatch.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}

