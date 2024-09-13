namespace IdeaCompany.Portfolio.Core.WorkExperiences.Models;

public class WorkExperience
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PortfolioId { get; set; }
    public string Role { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string UrlCompany { get; set; } = string.Empty;
    public string IconCompany { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; } = null;

    public Portfolios.Models.Portfolio Portfolio { get; set; }
}