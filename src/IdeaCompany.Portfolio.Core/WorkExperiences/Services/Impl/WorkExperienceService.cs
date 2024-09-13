using IdeaCompany.Portfolio.Core.WorkExperiences.Models;
using IdeaCompany.Portfolio.Core.WorkExperiences.Repositories;

namespace IdeaCompany.Portfolio.Core.WorkExperiences.Services.Impl;

public class WorkExperienceService(IWorkExperienceRepository workExperienceRepository) : IWorkExperienceService
{
    private IWorkExperienceRepository WorkExperienceRepository { get; } = workExperienceRepository;

    public async Task CreateWorkExperiencesAsync(List<WorkExperience> workExperiences)
    {
        await WorkExperienceRepository.AddRangeAsync(workExperiences);
    }
}