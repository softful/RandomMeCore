using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RandomMeCore.Core.Models;

namespace RandomMeCore.Core.Maps
{
    public class TitleMap : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> entity)
        {
            var genderConversion = new EnumToStringConverter<Gender>();

            entity
                .HasBaseType<NameBlock>()
                .Property(f => f.Gender)
                .HasConversion(genderConversion)
                .HasColumnName("gender");
        }
    }
}
