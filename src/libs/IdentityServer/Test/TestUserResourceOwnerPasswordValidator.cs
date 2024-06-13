


using IdentityModel;
using System.Threading.Tasks;
using System;
using IdentityServer8.Validation;

namespace IdentityServer8.Test;

/// <summary>
/// Resource owner password validator for test users
/// </summary>
/// <seealso cref="IResourceOwnerPasswordValidator" />
public class TestUserResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
{
    private readonly TestUserStore _users;
    private readonly IClock _clock;

    /// <summary>
    /// Initializes a new instance of the <see cref="TestUserResourceOwnerPasswordValidator"/> class.
    /// </summary>
    /// <param name="users">The users.</param>
    /// <param name="clock">The clock.</param>
    public TestUserResourceOwnerPasswordValidator(TestUserStore users, IClock clock)
    {
        _users = users;
        _clock = clock;
    }

    /// <summary>
    /// Validates the resource owner password credential
    /// </summary>
    /// <param name="context">The context.</param>
    /// <returns></returns>
    public Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
    {
        if (_users.ValidateCredentials(context.UserName, context.Password))
        {
            var user = _users.FindByUsername(context.UserName);
            context.Result = new GrantValidationResult(
                user.SubjectId ?? throw new ArgumentException("Subject ID not set", nameof(user.SubjectId)), 
                OidcConstants.AuthenticationMethods.Password, _clock.UtcNow.UtcDateTime, 
                user.Claims);
        }

        return Task.CompletedTask;
    }
}