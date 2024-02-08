using Booky.Application.Abstractions.Clock;
using Booky.Application.Abstractions.Email;
using Booky.Infrastructure.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booky.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddTransient<IDateTimeProvider, IDateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();
        
        return services;
    }
}