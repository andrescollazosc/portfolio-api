namespace IdeaCompany.Portfolio.Core.Portfolios.Services;

public interface IPortfolioService
{
    Task<Models.Portfolio?> GetPortfolioByTag(string portfolioTag);
}