using WhatWatch.Application.Contracts;

namespace WhatWatch.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}

