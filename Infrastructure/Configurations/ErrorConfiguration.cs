using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ErrorConfiguration : IEntityTypeConfiguration<Error>
{
    public void Configure(EntityTypeBuilder<Error> builder)
    {
        builder.HasKey(e => e.ErrorId);

        builder.Property(e => e.MissedKicks)
            .IsRequired();

        builder.Property(e => e.RecoveryTime)
            .IsRequired();

        builder.HasOne(e => e.Session)
            .WithOne(s => s.Error)
            .HasForeignKey<Error>(e => e.SessionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}