


using System;

namespace IdentityServer8;

class DefaultClock : IClock
{
    private readonly TimeProvider _timeProvider;

    public DefaultClock()
    {
        _timeProvider = TimeProvider.System;
    }

    public DefaultClock(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public DateTimeOffset UtcNow { get => _timeProvider.GetUtcNow(); }
}
