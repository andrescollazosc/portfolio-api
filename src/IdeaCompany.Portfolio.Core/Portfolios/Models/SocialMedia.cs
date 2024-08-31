namespace IdeaCompany.Portfolio.Core.Portfolios.Models;

public class SocialMedia
{
    public Guid Id { get; set; }
    public Guid PortfolioId { get; set; }
    public string Url { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Tag { get; set; } = string.Empty;

    public Portfolio Portfolio { get; set; }
}