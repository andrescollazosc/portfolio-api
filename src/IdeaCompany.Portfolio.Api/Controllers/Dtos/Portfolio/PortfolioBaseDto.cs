using IdeaCompany.Portfolio.Core.Portfolios.Models;

namespace IdeaCompany.Portfolio.Api.Controllers.Dtos.Portfolio;

public abstract class PortfolioBaseDto
{
    public string OwnerFirstName { get; set; } = string.Empty;
    public string OwnerLastName { get; set; } = string.Empty;
    public List<string> Emails { get; set; } = new ();
    public List<string> PhoneNumbers { get; set; } = new ();
    public List<SocialMedia> SocialMedias { get; set; } = [];
    public List<WorkExperienceDto>? WorkExperiences { get; set; }
    public string Location { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Summary { get; set; }
}