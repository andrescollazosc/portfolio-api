using FluentValidation;

namespace IdeaCompany.Portfolio.Core.Portfolios.Validations;

public class PortfolioValidator : AbstractValidator<Models.Portfolio>
{
    public PortfolioValidator()
    {
        RuleFor(x => x.PortfolioTag)
            .NotEmpty().WithMessage("Tag is required.")
            .MaximumLength(15).WithMessage("The tag field can only be a maximum of 15 characters.");

        RuleFor(x => x.OwnerFirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(80).WithMessage("The First name can only be a maximum of 80 characters.");

        RuleFor(x => x.OwnerLastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(80).WithMessage("The last name  can only be a maximum of 80 characters.");
        
        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required.")
            .MaximumLength(30).WithMessage("The Location field can only be a maximum of 30 characters.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title  is required.")
            .MaximumLength(30).WithMessage("The Title can only be a maximum of 30 characters.");

        RuleFor(x => x.Summary)
            .NotEmpty().WithMessage("Summary is required.")
            .MaximumLength(1000).WithMessage("The Summary  can only be a maximum of 1000 characters.");
    }
}