using System.Net;
using System.Net.Mail;
using FluentValidation;
using IdeaCompany.Portfolio.Core.EmailSettings.Models;

namespace IdeaCompany.Portfolio.Core.EmailSettings.Services.Impl;

public class EmailSettingsService : IEmailSettingsService
{
    public IValidator<Email> Validator { get; set; }
    
    public EmailSettingsService(IValidator<Email> validator)
    {
        Validator = validator;
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