namespace IdeaCompany.Portfolio.Api.Controllers.Dtos.Portfolio;

public class WorkExperienceDto
{
    public string Role { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public string UrlCompany { get; set; } = string.Empty;
    public string IconCompany { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}