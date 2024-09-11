using System.Text.Json;
using IdeaCompany.Portfolio.Core.Portfolios.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdeaCompany.Portfolio.Data.Ef.Mappings;

public class PortfolioMapping : IEntityTypeConfiguration<Core.Portfolios.Models.Portfolio>
{
    public void Configure(EntityTypeBuilder<Core.Portfolios.Models.Portfolio> builder)
    {
        builder.Property(x => x.Id);

        builder.Property(x => x.PortfolioTag)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(x => x.OwnerFirstName)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(x => x.OwnerLastName)
            .IsRequired()
            .HasMaxLength(80);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Location)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(x => x.Summary)
            .IsRequired()
            .HasMaxLength(1000);

        builder.HasIndex(x => x.PortfolioTag).IsUnique();

        builder.Property(x => x.PhoneNumbers)
            .IsRequired()
            .HasConversion(v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null));
        
        builder.Property(x => x.SocialMedias)
            .IsRequired()
            .HasConversion(v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                v => JsonSerializer.Deserialize<List<SocialMedia>>(v, (JsonSerializerOptions)null));
    }
}