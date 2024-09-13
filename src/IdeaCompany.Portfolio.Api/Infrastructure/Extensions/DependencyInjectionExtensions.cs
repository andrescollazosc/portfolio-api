using FluentValidation;
using IdeaCompany.Portfolio.Core.EmailSettings.Models;
using IdeaCompany.Portfolio.Core.EmailSettings.Repositories;
using IdeaCompany.Portfolio.Core.EmailSettings.Services;
using IdeaCompany.Portfolio.Core.EmailSettings.Services.Impl;
using IdeaCompany.Portfolio.Core.EmailSettings.Validations;
using IdeaCompany.Portfolio.Core.Portfolios.Repositories;
using IdeaCompany.Portfolio.Core.Portfolios.Services;
using IdeaCompany.Portfolio.Core.Portfolios.Services.Impl;
using IdeaCompany.Portfolio.Core.Portfolios.Validations;
using IdeaCompany.Portfolio.Core.WorkExperiences.Repositories;
using IdeaCompany.Portfolio.Core.WorkExperiences.Services;
using IdeaCompany.Portfolio.Core.WorkExperiences.Services.Impl;
using IdeaCompany.Portfolio.Data.Ef.Repositories;

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
        services.AddScoped<IPortfolioService, PortfolioService>();
        services.AddScoped<IWorkExperienceService, WorkExperienceService>();
    }

    private static void RegisterRepositories(this IServiceCollection services)
    {
        services.AddScoped<IEmailSettingRepository, EmailSettingRepository>();
        services.AddScoped<IPortfolioRepository, PortfolioRepository>();
        services.AddScoped<IWorkExperienceRepository, WorkExperienceRepository>();
    }

    private static void RegisterValidators(this IServiceCollection services)
    {
        services.AddSingleton<IValidator<Email>, EmailValidation>();
        services.AddSingleton<IValidator<EmailSetting>, EmailSettingValidator>();
        services.AddSingleton<IValidator<Core.Portfolios.Models.Portfolio>, PortfolioValidator>();
    }
}