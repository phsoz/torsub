using WhatWatch.Application.Common.Interfaces;

namespace WhatWatch.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}

