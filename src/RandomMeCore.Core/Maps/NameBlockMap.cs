using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RandomMeCore.Core.Models;

namespace RandomMeCore.Core.Maps
{
    public class NameBlockMap : IEntityTypeConfiguration<NameBlock>
    {
        public void Configure(EntityTypeBuilder<NameBlock> entity)
        {
            entity.Property(f => f.Id).HasColumnName("Id").UseMySqlIdentityColumn();
            entity.Property(f => f.Value).HasColumnName("name");
            entity.Property(f => f.BlockType).HasColumnName("block_type");

            entity.HasDiscriminator(f => f.BlockType)
            .HasValue<Title>(NameBlockType.Title)
            .HasValue<FirstName>(NameBlockType.FirstName)
            .HasValue<LastName>(NameBlockType.LastName);
            
            entity.HasOne(f => f.Country)
                    .WithMany(p => p.NameBlocks)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
