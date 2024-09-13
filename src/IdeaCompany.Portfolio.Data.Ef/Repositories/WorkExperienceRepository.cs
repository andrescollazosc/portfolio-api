using IdeaCompany.Portfolio.Core.WorkExperiences.Models;
using IdeaCompany.Portfolio.Core.WorkExperiences.Repositories;
using IdeaCompany.Portfolio.Data.Ef.Common.Repositories;

namespace IdeaCompany.Portfolio.Data.Ef.Repositories;

public class WorkExperienceRepository(PortfolioDbContext dbContext)
    : GenericEfRepository<WorkExperience, PortfolioDbContext>(dbContext), IWorkExperienceRepository
{
    
}