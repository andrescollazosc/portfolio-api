using FluentValidation;
using IdeaCompany.Portfolio.Core.Portfolios.Repositories;
using IdeaCompany.Portfolio.Core.WorkExperiences.Services;

namespace IdeaCompany.Portfolio.Core.Portfolios.Services.Impl;

public class PortfolioService : IPortfolioService
{
    private IPortfolioRepository PortfolioRepository { get; }
    private IValidator<Models.Portfolio> Validator { get; }
    
    public PortfolioService(IPortfolioRepository portfolioRepository, IValidator<Models.Portfolio> validator)
    {
        PortfolioRepository = portfolioRepository;
        Validator = validator;
    }
    
    public async Task<Models.Portfolio?> GetPortfolioByTag(string portfolioTag)
    {
        return await PortfolioRepository.GetByTag(portfolioTag);
    }

    public async Task CreatePortfolioAsync(Models.Portfolio portfolio)
    {
        portfolio.Id = Guid.NewGuid();
        var validationUser = await Validator.ValidateAsync(portfolio);
            
        if (!validationUser.IsValid)
        {
            throw new ValidationException(validationUser.Errors);
        }
            
        await PortfolioRepository.AddAsync(portfolio);
    }

    public async Task UpdatePortfolioAsync(Models.Portfolio portfolio)
    {
        throw new NotImplementedException();
    }
}