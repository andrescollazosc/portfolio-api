using IdeaCompany.Portfolio.Core.WorkExperiences.Models;

namespace IdeaCompany.Portfolio.Core.Portfolios.Models;

public class Portfolio
{
    public Guid Id { get; set; }
    public string PortfolioTag { get; set; } = string.Empty;
    public string OwnerFirstName { get; set; } = string.Empty;
    public string OwnerLastName { get; set; } = string.Empty;
    public List<string> Emails { get; set; } = new ();
    public List<string> PhoneNumbers { get; set; } = new ();
    public List<SocialMedia> SocialMedias { get; set; } = [];
    public string Location { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Summary { get; set; }
    
    public IEnumerable<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
}