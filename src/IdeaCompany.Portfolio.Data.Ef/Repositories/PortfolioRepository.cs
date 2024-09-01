using IdeaCompany.Portfolio.Core.Portfolios.Repositories;
using IdeaCompany.Portfolio.Data.Ef.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IdeaCompany.Portfolio.Data.Ef.Repositories;

public class PortfolioRepository(PortfolioDbContext dbContext)
    : GenericEfRepository<Core.Portfolios.Models.Portfolio, PortfolioDbContext>(dbContext), IPortfolioRepository
{
    public async Task<Core.Portfolios.Models.Portfolio?> GetByTag(string tag)
    {
        var portfolio = await DbContext.Portfolios.SingleOrDefaultAsync(x => x.PortfolioTag == tag);
        
        return portfolio;
    }
}