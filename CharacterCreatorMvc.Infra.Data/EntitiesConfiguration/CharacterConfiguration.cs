using CharacterCreatorMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CharacterCreatorMvc.Infra.Data.EntitiesConfiguration
{
    public class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Description).HasMaxLength(100).IsRequired();

            builder.HasOne(e => e.CharacterType).WithMany(e => e.Characters)
                .HasForeignKey(e => e.CharacterTypeId);
        }
    }
}
