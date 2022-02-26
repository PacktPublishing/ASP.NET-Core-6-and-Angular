using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WorldCitiesAPI.Data.Models
{
    /// <summary>
    /// IMPORTANT NOTE: the following class is redundant 
    /// (since we've already configured our entities using Data Annotations)
    /// and has been left there for demonstration purposes only.
    /// See "Entity Types configuration methods" in Chapter 4 for details.
    /// </summary>
    public class CityEntityTypeConfiguration
        : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Cities");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
            builder
                .HasOne(x => x.Country)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.CountryId);
            builder.Property(x => x.Lat).HasColumnType("decimal(7,4)");
            builder.Property(x => x.Lon).HasColumnType("decimal(7,4)");
        }
    }
}
