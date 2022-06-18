using TorSub.Application.Contracts;

namespace TorSub.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}

