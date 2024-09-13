namespace IdeaCompany.Portfolio.Core.Portfolios.Services;

public interface IPortfolioService
{
    Task<Models.Portfolio?> GetPortfolioByTag(string portfolioTag);
    Task CreatePortfolioAsync(Models.Portfolio portfolio);
    Task UpdatePortfolioAsync(Models.Portfolio portfolio);
}