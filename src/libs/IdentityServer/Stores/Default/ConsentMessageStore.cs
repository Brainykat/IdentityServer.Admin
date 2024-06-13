﻿


using System.Threading.Tasks;
using IdentityServer8.Models;

namespace IdentityServer8.Stores;

internal class ConsentMessageStore : IConsentMessageStore
{
    protected readonly MessageCookie<ConsentResponse> Cookie;

    public ConsentMessageStore(MessageCookie<ConsentResponse> cookie)
    {
        Cookie = cookie;
    }

    public virtual Task DeleteAsync(string id)
    {
        using var activity = Tracing.StoreActivitySource.StartActivity("ConsentMessageStore.Delete");
        
        Cookie.Clear(id);
        return Task.CompletedTask;
    }

    public virtual Task<Message<ConsentResponse>> ReadAsync(string id)
    {
        using var activity = Tracing.StoreActivitySource.StartActivity("ConsentMessageStore.Read");
        
        return Task.FromResult(Cookie.Read(id));
    }

    public virtual Task WriteAsync(string id, Message<ConsentResponse> message)
    {
        using var activity = Tracing.StoreActivitySource.StartActivity("ConsentMessageStore.Write");

        Cookie.Write(id, message);
        return Task.CompletedTask;
    }
}