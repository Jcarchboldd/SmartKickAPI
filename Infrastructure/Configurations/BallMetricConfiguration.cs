using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class BallMetricConfiguration : IEntityTypeConfiguration<BallMetric>
{
    public void Configure(EntityTypeBuilder<BallMetric> builder)
    {
        builder.HasKey(bm => bm.MetricId);

        builder.Property(bm => bm.Timestamp)
            .IsRequired();

        builder.Property(bm => bm.KickCount)
            .IsRequired();

        builder.Property(bm => bm.AverageHeight)
            .IsRequired();

        builder.HasOne(bm => bm.Session)
            .WithMany(s => s.BallMetrics)
            .HasForeignKey(bm => bm.SessionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}