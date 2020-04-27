using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RandomMeCore.Core.Models;

namespace RandomMeCore.Core.Maps
{
    public class PhotoMap : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> entity)
        {
            entity.ToTable("Photo");
            entity.HasKey(f => f.Id);
            entity.Property(f => f.FilePath).HasColumnName("file_path");

            var genderConversion = new EnumToStringConverter<Gender>();

            entity.Property(f => f.Gender)
                .HasConversion(genderConversion)
                .HasColumnName("gender");
        }
    }
}
