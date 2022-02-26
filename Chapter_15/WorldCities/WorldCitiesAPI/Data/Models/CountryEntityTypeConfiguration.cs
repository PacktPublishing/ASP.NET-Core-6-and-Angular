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
    public class CountryEntityTypeConfiguration
        : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();
        }
    }
}
