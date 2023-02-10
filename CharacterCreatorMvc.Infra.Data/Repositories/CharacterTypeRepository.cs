using CharacterCreatorMvc.Domain.Entities;
using CharacterCreatorMvc.Domain.Interfaces;
using CharacterCreatorMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CharacterCreatorMvc.Infra.Data.Repositories
{
    public class CharacterTypeRepository : ICharacterTypeRepository
    {
        ApplicationDbContext _characterTypeContext;
        public CharacterTypeRepository(ApplicationDbContext context)
        {
            _characterTypeContext = context;
        }

        public async Task<CharacterType> CreateAsync(CharacterType characterType)
        {
            _characterTypeContext.Add(characterType);
            await _characterTypeContext.SaveChangesAsync();
            return characterType;
        }

        public async Task<CharacterType> GetByIdAsync(Guid id)
        {
            return await _characterTypeContext.CharactersTypes.FindAsync(id);
        }

        public async Task<IEnumerable<CharacterType>> GetCharacterTypesAsync()
        {
            return await _characterTypeContext.CharactersTypes.ToListAsync();
        }

        public async Task<CharacterType> RemoveAsync(CharacterType characterType)
        {
            _characterTypeContext.Remove(characterType);
            await _characterTypeContext.SaveChangesAsync();
            return characterType;
        }

        public async Task<CharacterType> UpdateAsync(CharacterType characterType)
        {
            _characterTypeContext.Update(characterType);
            await _characterTypeContext.SaveChangesAsync();
            return characterType;
        }
    }
}
