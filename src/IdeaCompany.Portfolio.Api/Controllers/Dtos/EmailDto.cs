namespace IdeaCompany.Portfolio.Api.Controllers.Dtos;

public class EmailDto
{
    public string From { get; set; }
    public string To { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
}