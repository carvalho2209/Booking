using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;

namespace Booky.Infrastructure.Authentication;

internal sealed class JwtBearerOptionsSetup(IOptions<AuthenticationOptions> options)
    : IConfigureNamedOptions<JwtBearerOptions>
{
    private readonly AuthenticationOptions _authenticationOptions = options.Value;

    public void Configure(JwtBearerOptions options)
    {
        options.Audience = _authenticationOptions.Audience;
        options.MetadataAddress = _authenticationOptions.MetadataUrl;
        options.RequireHttpsMetadata = _authenticationOptions.RequiredHttpsMetadata;
        options.TokenValidationParameters.ValidIssuer = _authenticationOptions.Issuer;
    }

    public void Configure(string? name, JwtBearerOptions options)
    {
        Configure(options);
    }
}