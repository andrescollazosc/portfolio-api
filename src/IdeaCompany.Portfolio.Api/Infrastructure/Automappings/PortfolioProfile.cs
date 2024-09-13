using AutoMapper;
using IdeaCompany.Portfolio.Api.Controllers.Dtos.Portfolio;

namespace IdeaCompany.Portfolio.Api.Infrastructure.Automappings;

public class PortfolioProfile : Profile
{
    public PortfolioProfile()
    {
        CreateMap<CreatePortfolioDto, Core.Portfolios.Models.Portfolio>();
        
        CreateMap<Core.Portfolios.Models.Portfolio, ResponsePortfolioDto>();
        
    }
}