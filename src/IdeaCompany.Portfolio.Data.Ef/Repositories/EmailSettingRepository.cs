using IdeaCompany.Portfolio.Core.EmailSettings.Models;
using IdeaCompany.Portfolio.Core.EmailSettings.Repositories;
using IdeaCompany.Portfolio.Data.Ef.Common.Repositories;

namespace IdeaCompany.Portfolio.Data.Ef.Repositories;

public class EmailSettingRepository(PortfolioDbContext dbContext)
    : GenericEfRepository<EmailSetting, PortfolioDbContext>(dbContext), IEmailSettingRepository
{
    
}