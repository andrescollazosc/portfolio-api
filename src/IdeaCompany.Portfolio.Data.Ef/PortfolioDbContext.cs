using IdeaCompany.Portfolio.Core.EmailSettings.Models;
using IdeaCompany.Portfolio.Core.WorkExperiences.Models;
using IdeaCompany.Portfolio.Data.Ef.Mappings;
using Microsoft.EntityFrameworkCore;

namespace IdeaCompany.Portfolio.Data.Ef;

public class PortfolioDbContext : DbContext
{
    public DbSet<EmailSetting> EmailSettings { get; set; }
    public DbSet<Core.Portfolios.Models.Portfolio> Portfolios { get; set; }
    public DbSet<WorkExperience> WorkExperiences { get; set; }

    static PortfolioDbContext() { }
    
    public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new EmailSettingMapping().Configure(modelBuilder.Entity<EmailSetting>());
        new PortfolioMapping().Configure(modelBuilder.Entity<Core.Portfolios.Models.Portfolio>());
        new WorkExperienceMapping().Configure(modelBuilder.Entity<WorkExperience>());
    }
}