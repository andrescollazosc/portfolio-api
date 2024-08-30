using IdeaCompany.Portfolio.Core.EmailSettings.Models;

namespace IdeaCompany.Portfolio.Core.EmailSettings.Services;

public interface IEmailSettingsService
{
    Task SendEmail(Email email);
}