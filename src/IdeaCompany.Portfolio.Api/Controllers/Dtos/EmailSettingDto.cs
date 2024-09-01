namespace IdeaCompany.Portfolio.Api.Controllers.Dtos;

public class EmailSettingDto
{
    public string Email { get; set; } = string.Empty;
    public string PasswordApplication { get; set; } = string.Empty;
    public string SmtpClient { get; set; } = string.Empty;
    public int Port { get; set; }
}