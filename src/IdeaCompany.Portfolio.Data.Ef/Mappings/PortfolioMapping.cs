using System.Text.Json;
using IdeaCompany.Portfolio.Core.Portfolios.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        var emailsComparer = new ValueComparer<List<string>>(
            (c1, c2) => c1.SequenceEqual(c2), 
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList());
        
        builder.Property(x => x.Emails)
            .IsRequired()
            .HasConversion(v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null))
            .Metadata.SetValueComparer(emailsComparer);
        
        var stringListComparer = new ValueComparer<List<string>>(
            (c1, c2) => c1.SequenceEqual(c2), 
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
            c => c.ToList());
        
        builder.Property(x => x.PhoneNumbers)
            .IsRequired()
            .HasConversion(v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null))
            .Metadata.SetValueComparer(stringListComparer);
        
        var socialMediaListComparer = new ValueComparer<List<SocialMedia>>(
            (c1, c2) => c1.SequenceEqual(c2),
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.Url.GetHashCode(), v.Icon.GetHashCode(), v.Tag.GetHashCode())),
            c => c.Select(x => new SocialMedia { Url = x.Url, Icon = x.Icon, Tag = x.Tag }).ToList()); 
        
        builder.Property(x => x.SocialMedias)
            .IsRequired()
            .HasConversion(v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null!),
                v => JsonSerializer.Deserialize<List<SocialMedia>>(v, (JsonSerializerOptions)null))
            .Metadata.SetValueComparer(socialMediaListComparer);
    }
}