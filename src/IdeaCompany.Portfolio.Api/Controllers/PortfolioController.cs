using AutoMapper;
using IdeaCompany.Portfolio.Api.Controllers.Dtos.Portfolio;
using IdeaCompany.Portfolio.Core.Common.Data;
using IdeaCompany.Portfolio.Core.Portfolios.Services;
using IdeaCompany.Portfolio.Core.WorkExperiences.Models;
using IdeaCompany.Portfolio.Core.WorkExperiences.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdeaCompany.Portfolio.Api.Controllers;

[ApiController]
[Route("/api/portfolio/{portfolioId}/")]
public class PortfolioController : Controller
{
    private IPortfolioService PortfolioService { get; }
    private IWorkExperienceService WorkExperienceService { get; }
    private IMapper Mapper { get; }
    private IUnitOfWork UnitOfWork { get; }

    public PortfolioController(IPortfolioService portfolioService, IMapper mapper, IUnitOfWork unitOfWork,
        IWorkExperienceService workExperienceService)
    {
        PortfolioService = portfolioService;
        Mapper = mapper;
        UnitOfWork = unitOfWork;
        WorkExperienceService = workExperienceService;
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult<ResponsePortfolioDto>> Get(string portfolioId)
    {
        try
        {
            var portfolio = await PortfolioService.GetPortfolioByTag(portfolioId);

            if (portfolio is null)
            {
                return NotFound("Portfolio was not found.");
            }

            return Ok(Mapper.Map<ResponsePortfolioDto>(portfolio));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
    

    [HttpPost]
    [Route("create")]
    public async Task<ActionResult<ResponsePortfolioDto>> Create(string portfolioId,
        [FromBody] CreatePortfolioDto createPortfolioDto)
    {
        try
        {
            var hasPortfolio = await PortfolioService.GetPortfolioByTag(portfolioId);

            if (hasPortfolio is not null)
            {
                return BadRequest("Portfolio already exists.");
            }

            var portfolio = Mapper.Map<Core.Portfolios.Models.Portfolio>(createPortfolioDto);
            portfolio.PortfolioTag = portfolioId;
            await PortfolioService.CreatePortfolioAsync(portfolio);

            var workExperiences = portfolio.WorkExperiences.Select(x => Mapper.Map<WorkExperience>(x)).ToList();
            workExperiences.ForEach(x => x.Portfolio = portfolio);
            await WorkExperienceService.CreateWorkExperiencesAsync(workExperiences);

            await UnitOfWork.CommitAsync();

            return Ok(Mapper.Map<ResponsePortfolioDto>(portfolio));
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}