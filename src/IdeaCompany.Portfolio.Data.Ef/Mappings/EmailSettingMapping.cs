using IdeaCompany.Portfolio.Core.EmailSettings.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdeaCompany.Portfolio.Data.Ef.Mappings;

public class EmailSettingMapping : IEntityTypeConfiguration<EmailSetting>
{
    public void Configure(EntityTypeBuilder<EmailSetting> builder)
    {
        builder.Property(x=>x.Id);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);
        
        builder.Property(x => x.PasswordApplication)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(x => x.SmtpClient)
            .IsRequired();
        
        builder.Property(x => x.Port)
            .IsRequired();
        
        builder.HasOne(x => x.Portfolio)
            .WithMany()
            .HasForeignKey(p => p.PortfolioId)
            .IsRequired();
    }
}