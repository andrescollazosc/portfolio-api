using System.Net;
using System.Net.Mail;
using FluentValidation;
using IdeaCompany.Portfolio.Core.Common.Services;
using IdeaCompany.Portfolio.Core.EmailSettings.Models;
using IdeaCompany.Portfolio.Core.EmailSettings.Repositories;

namespace IdeaCompany.Portfolio.Core.EmailSettings.Services.Impl;

public class EmailSettingsService : IEmailSettingsService
{
    private IValidator<Email> Validator { get; }
    private IValidator<EmailSetting> EmailSettingValidator { get; }
    private IEmailSettingRepository EmailSettingRepository { get; }
    
    
    public EmailSettingsService(IValidator<Email> validator, IValidator<EmailSetting> emailSettingValidator, IEmailSettingRepository emailSettingRepository)
    {
        Validator = validator;
        EmailSettingValidator = emailSettingValidator;
        EmailSettingRepository = emailSettingRepository;
    }
    
    public async Task SendEmail(Email email)
    {
        var validation = await Validator.ValidateAsync(email);
        
        if (!validation.IsValid)
        {
            throw new ValidationException(validation.Errors);
        }
        
        PopulateEmail(email);
    }

    public async Task AddEmailSetting(EmailSetting emailSetting)
    {
        var validation = await EmailSettingValidator.ValidateAsync(emailSetting);
        
        if (!validation.IsValid)
        {
            throw new ValidationException(validation.Errors);
        }

        emailSetting.PasswordApplication = emailSetting.PasswordApplication.Encrypt();
        
        await EmailSettingRepository.AddAsync(emailSetting);
    }

    private static void PopulateEmail(Email email)
    {
        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential("Your Email Here", "Your Pass Here")
        };

        var emailMessage = new MailMessage(email.To, "andrescollazosc@gmail.com");
        emailMessage.Subject = email.Subject;
        emailMessage.Body = email.Body;
        client.Send(emailMessage);
    }
}