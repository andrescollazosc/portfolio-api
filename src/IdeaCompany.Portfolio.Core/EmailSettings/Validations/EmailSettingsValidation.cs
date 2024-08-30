using FluentValidation;
using IdeaCompany.Portfolio.Core.EmailSettings.Models;

namespace IdeaCompany.Portfolio.Core.EmailSettings.Validations;

public class EmailSettingsValidation : AbstractValidator<Email>
{
    public EmailSettingsValidation()
    {
        RuleFor(x => x.To)
            .NotEmpty().WithMessage("Email To is required.")
            .MaximumLength(100).WithMessage("The email can only be a maximum of 100 characters.")
            .EmailAddress().WithMessage("The email address must be a valid email address.");
        
        RuleFor(x => x.From)
            .NotEmpty().WithMessage("Email From is required.")
            .MaximumLength(100).WithMessage("The email can only be a maximum of 100 characters.")
            .EmailAddress().WithMessage("The email address must be a valid email address.");

        RuleFor(x => x.Subject)
            .NotEmpty().WithMessage("Subject is required.")
            .MaximumLength(100).WithMessage("The Subject can only be a maximum of 100 characters.");
        
        RuleFor(x => x.Body)
            .NotEmpty().WithMessage("Body is required.")
            .MaximumLength(500).WithMessage("The Body field can only be a maximum of 500 characters.");
    }    
}