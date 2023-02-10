using CharacterCreatorMvc.Application.DTOs;

namespace CharacterCreatorMvc.Application.Interfaces
{
    public interface ICharacterService
    {
        Task<IEnumerable<CharacterDTO>> GetCharactersAsync();
        Task<CharacterDTO> GetCharacterByIdAsync(Guid id);
        Task AddAsync(CharacterDTO characterTypeDTO);
        Task UpdateAsync(CharacterDTO characterTypeDTO);
        Task RemoveAsync(Guid id);
    }
}
