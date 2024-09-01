using IdeaCompany.Portfolio.Core.Portfolios.Repositories;

namespace IdeaCompany.Portfolio.Core.Portfolios.Services.Impl;

public class PortfolioService : IPortfolioService
{
    private IPortfolioRepository PortfolioRepository { get; }
    
    public PortfolioService(IPortfolioRepository portfolioRepository)
    {
        PortfolioRepository = portfolioRepository;
    }
    
    public async Task<Models.Portfolio?> GetPortfolioByTag(string portfolioTag)
    {
        return await PortfolioRepository.GetByTag(portfolioTag);
    }
}