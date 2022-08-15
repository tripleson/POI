using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurate;

public class POIConfigurate
{
}

public class PointConfigurate : IEntityTypeConfiguration<Point>
{
    public void Configure(EntityTypeBuilder<Point> builder)
    {
        builder
            .HasKey(a => new { a.Latitude, a.Longitude });
    }
}