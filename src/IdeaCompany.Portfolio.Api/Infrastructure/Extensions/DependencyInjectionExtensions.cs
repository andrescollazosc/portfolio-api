using FluentValidation;
using IdeaCompany.Portfolio.Core.EmailSettings.Models;
using IdeaCompany.Portfolio.Core.EmailSettings.Services;
using IdeaCompany.Portfolio.Core.EmailSettings.Services.Impl;
using IdeaCompany.Portfolio.Core.EmailSettings.Validations;

namespace IdeaCompany.Portfolio.Api.Infrastructure.Extensions;

public static class DependencyInjectionExtensions
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.RegisterServices();
        services.RegisterRepositories();
        services.RegisterValidators();
    }

    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailSettingsService, EmailSettingsService>();
    }

    private static void RegisterRepositories(this IServiceCollection services)
    {
    }

    private static void RegisterValidators(this IServiceCollection services)
    {
        services.AddSingleton<IValidator<Email>, EmailValidation>();
    }
}