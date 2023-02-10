using CharacterCreatorMvc.Domain.Entities;

namespace CharacterCreatorMvc.Domain.Interfaces
{
    public interface ICharacterTypeRepository
    {
        Task<IEnumerable<CharacterType>> GetCharacterTypesAsync();
        Task<CharacterType> GetByIdAsync(Guid id);

        Task<CharacterType> CreateAsync(CharacterType characterType);
        Task<CharacterType> UpdateAsync(CharacterType characterType);
        Task<CharacterType> RemoveAsync(CharacterType characterType);
    }
}
