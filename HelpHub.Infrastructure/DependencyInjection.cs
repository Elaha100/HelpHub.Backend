using HelpHub.Application.Interfaces;
using HelpHub.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;


namespace HelpHub.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {
        services.AddScoped<IHelpRequestRepository, HelpRequestRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();


        return services;
    }
}