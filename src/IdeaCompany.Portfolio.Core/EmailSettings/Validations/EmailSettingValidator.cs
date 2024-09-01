using FluentValidation;
using IdeaCompany.Portfolio.Core.EmailSettings.Models;

namespace IdeaCompany.Portfolio.Core.EmailSettings.Validations;

public class EmailSettingValidator : AbstractValidator<EmailSetting>
{
    public EmailSettingValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .MaximumLength(100).WithMessage("The email can only be a maximum of 100 characters.")
            .EmailAddress().WithMessage("The email address must be a valid email address.");

        RuleFor(x => x.PasswordApplication)
            .NotEmpty().WithMessage("Password is required.")
            .MaximumLength(30).WithMessage("The Password can only be a maximum of 30 characters.");
        
        RuleFor(x => x.SmtpClient)
            .NotEmpty().WithMessage("SmtpClient is required.");
        
        RuleFor(x => x.Port)
            .NotEmpty().WithMessage("Port is required.");
    }
}