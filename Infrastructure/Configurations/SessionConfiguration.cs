using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.HasKey(s => s.SessionId);

        builder.Property(s => s.StartTime)
            .IsRequired();

        builder.Property(s => s.EndTime)
            .IsRequired();

        // Exclude the computed field
        builder.Ignore(s => s.TotalTime);

        builder.HasOne(s => s.Player)
            .WithMany(p => p.Sessions)
            .HasForeignKey(s => s.PlayerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}