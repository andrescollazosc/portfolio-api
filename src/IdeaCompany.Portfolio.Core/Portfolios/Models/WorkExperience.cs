namespace IdeaCompany.Portfolio.Core.Portfolios.Models;

public class WorkExperience
{
    public Guid Id { get; set; }
    public Guid PortfolioId { get; set; }
    public string Role { get; set; } = string.Empty;
    public string ComanyName { get; set; } = string.Empty;
    public string UrlCompany { get; set; } = string.Empty;
    public string IconCompany { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public Portfolio Portfolio { get; set; }
}