using IdeaCompany.Portfolio.Core.Portfolios.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdeaCompany.Portfolio.Data.Ef.Mappings;

public class WorkExperienceMapping : IEntityTypeConfiguration<Core.Portfolios.Models.WorkExperience>
{
    public void Configure(EntityTypeBuilder<WorkExperience> builder)
    {
        builder.Property(x => x.Id);

        builder.Property(x => x.Role)
            .IsRequired()
            .HasMaxLength(40);

        builder.Property(x => x.ComanyName)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(x => x.UrlCompany)
            .IsRequired()
            .HasMaxLength(40);

        builder.Property(x => x.IconCompany)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.EndDate)
            .IsRequired();
        
        // builder.HasOne(x => x.Portfolio)
        //     .WithMany()
        //     .HasForeignKey(p => p.PortfolioId)
        //     .IsRequired();
    }
}