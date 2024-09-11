using IdeaCompany.Portfolio.Core.EmailSettings.Models;
using IdeaCompany.Portfolio.Data.Ef.Mappings;
using Microsoft.EntityFrameworkCore;

namespace IdeaCompany.Portfolio.Data.Ef;

public class PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : DbContext(options)
{
    public DbSet<EmailSetting> EmailSettings { get; set; }
    public DbSet<Core.Portfolios.Models.Portfolio> Portfolios { get; set; }
    public DbSet<Core.Portfolios.Models.WorkExperience> WorkExperiences { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new EmailSettingMapping().Configure(modelBuilder.Entity<EmailSetting>());
        new PortfolioMapping().Configure(modelBuilder.Entity<Core.Portfolios.Models.Portfolio>());
        new WorkExperienceMapping().Configure(modelBuilder.Entity<Core.Portfolios.Models.WorkExperience>());
    }
}