using AutoMapper;
using IdeaCompany.Portfolio.Api.Controllers.Dtos.Portfolio;
using IdeaCompany.Portfolio.Core.Portfolios.Models;
using IdeaCompany.Portfolio.Core.WorkExperiences.Models;

namespace IdeaCompany.Portfolio.Api.Infrastructure.Automappings;

public class WorkExperienceProfile : Profile
{
    public WorkExperienceProfile()
    {
        CreateMap<WorkExperienceDto, WorkExperience>()
            .ReverseMap();
    }
}