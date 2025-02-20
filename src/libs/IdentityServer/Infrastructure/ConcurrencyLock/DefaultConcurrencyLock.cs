


using System;
using System.Threading;
using System.Threading.Tasks;

namespace IdentityServer8.Internal;

/// <summary>
/// Default implementation.
/// </summary>
public class DefaultConcurrencyLock<T> : IConcurrencyLock<T>
{
    static readonly SemaphoreSlim Lock = new SemaphoreSlim(1);

    /// <inheritdoc/>
    public Task<bool> LockAsync(int millisecondsTimeout)
    {
        if (millisecondsTimeout <= 0)
        {
            throw new ArgumentException("millisecondsTimeout must be greater than zero.");
        }
            
        return Lock.WaitAsync(millisecondsTimeout);
    }

    /// <inheritdoc/>
    public void Unlock()
    {
        Lock.Release();
    }
}