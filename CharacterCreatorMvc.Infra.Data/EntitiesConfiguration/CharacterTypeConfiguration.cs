using CharacterCreatorMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CharacterCreatorMvc.Infra.Data.EntitiesConfiguration
{
    public class CharacterTypeConfiguration : IEntityTypeConfiguration<CharacterType>
    {
        public void Configure(EntityTypeBuilder<CharacterType> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Id).HasDefaultValueSql("newsequentialid()");

            builder.HasData(
                new CharacterType(Guid.NewGuid(), "Warrior"),
                new CharacterType(Guid.NewGuid(), "Mage"),
                new CharacterType(Guid.NewGuid(), "Barbarian"),
                new CharacterType(Guid.NewGuid(), "Sorcerer")
                );
        }
    }
}
