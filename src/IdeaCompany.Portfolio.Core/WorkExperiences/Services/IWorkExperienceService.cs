using IdeaCompany.Portfolio.Core.WorkExperiences.Models;

namespace IdeaCompany.Portfolio.Core.WorkExperiences.Services;

public interface IWorkExperienceService
{
    Task CreateWorkExperiencesAsync(List<WorkExperience> workExperiences);
}