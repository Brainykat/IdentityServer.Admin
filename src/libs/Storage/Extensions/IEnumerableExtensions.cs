


using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

#pragma warning disable 1591

namespace IdentityServer8.Extensions;

internal static class IEnumerableExtensions
{
    [DebuggerStepThrough]
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
    {
        if (list == null)
        {
            return true;
        }

        if (!list.Any())
        {
            return true;
        }

        return false;
    }
}