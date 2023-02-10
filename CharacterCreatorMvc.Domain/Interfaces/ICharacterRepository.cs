using CharacterCreatorMvc.Domain.Entities;

namespace CharacterCreatorMvc.Domain.Interfaces
{
    public interface ICharacterRepository
    {
        Task<IEnumerable<Character>> GetCharactersAsync();
        Task<Character> GetByIdAsync(Guid id);
        Task<Character> CreateAsync(Character character);
        Task<Character> UpdateAsync(Character character);
        Task<Character> RemoveAsync(Character character);
    }
}
