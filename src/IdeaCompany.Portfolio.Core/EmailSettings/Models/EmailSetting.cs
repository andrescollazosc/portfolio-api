namespace IdeaCompany.Portfolio.Core.EmailSettings.Models;

public class EmailSetting
{
    public Guid Id { get; set; }
    public Guid PortfolioId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PasswordApplication { get; set; } = string.Empty;
    public string SmtpClient { get; set; } = string.Empty;
    public int Port { get; set; }

    public Portfolios.Models.Portfolio Portfolio { get; set; }
}