using Microsoft.EntityFrameworkCore;

namespace IdeaCompany.Portfolio.Data.Ef;

public class PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : DbContext(options)
{
    
}