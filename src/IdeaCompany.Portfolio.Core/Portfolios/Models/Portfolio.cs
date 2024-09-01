namespace IdeaCompany.Portfolio.Core.Portfolios.Models;

public class Portfolio
{
    public Guid Id { get; set; }
    public string PortfolioTag { get; set; } = string.Empty;
    public string OwnerFirstName { get; set; } = string.Empty;
    public string OwnerLastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Summary { get; set; }
    public IEnumerable<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    public IEnumerable<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
}