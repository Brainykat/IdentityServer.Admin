


using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace IdentityServer8.Hosting.FederatedSignOut;

internal class AuthenticationRequestSignOutHandlerWrapper : AuthenticationRequestHandlerWrapper, IAuthenticationSignOutHandler
{
    private readonly IAuthenticationSignOutHandler _inner;

    public AuthenticationRequestSignOutHandlerWrapper(IAuthenticationSignOutHandler inner, IHttpContextAccessor httpContextAccessor)
        : base((IAuthenticationRequestHandler)inner, httpContextAccessor)
    {
        _inner = inner;
    }

    public Task SignOutAsync(AuthenticationProperties properties)
    {
        return _inner.SignOutAsync(properties);
    }
}