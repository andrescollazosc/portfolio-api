using IdeaCompany.Portfolio.Core.Common.Repositories;

namespace IdeaCompany.Portfolio.Core.Portfolios.Repositories;

public interface IPortfolioRepository : IGenericRepository<Models.Portfolio>
{
    Task<Models.Portfolio?> GetByTag(string tag);
}