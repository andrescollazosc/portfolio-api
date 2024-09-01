using IdeaCompany.Portfolio.Core.EmailSettings.Models;
using IdeaCompany.Portfolio.Data.Ef.Mappings;
using Microsoft.EntityFrameworkCore;

namespace IdeaCompany.Portfolio.Data.Ef;

public class PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : DbContext(options)
{
    public DbSet<EmailSetting> EmailSetting { get; set; }
    public DbSet<Core.Portfolios.Models.Portfolio> Portfolios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new EmailSettingMapping().Configure(modelBuilder.Entity<EmailSetting>());
    }
}