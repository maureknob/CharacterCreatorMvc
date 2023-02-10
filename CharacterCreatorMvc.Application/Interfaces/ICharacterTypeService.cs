using CharacterCreatorMvc.Application.DTOs;

namespace CharacterCreatorMvc.Application.Interfaces
{
    public interface ICharacterTypeService
    {
        Task<IEnumerable<CharacterTypeDTO>> GetCharacterTypesAsync();
        Task<CharacterTypeDTO> GetCharacterTypeByIdAsync(Guid id);
        Task AddAsync(CharacterTypeDTO characterTypeDTO);
        Task UpdateAsync(CharacterTypeDTO characterTypeDTO);
        Task RemoveAsync(Guid id);
    }
}
