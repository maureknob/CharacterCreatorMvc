using CharacterCreatorMvc.Domain.Entities;
using CharacterCreatorMvc.Domain.Interfaces;
using CharacterCreatorMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CharacterCreatorMvc.Infra.Data.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        ApplicationDbContext _characterContext;

        public CharacterRepository(ApplicationDbContext context)
        {
            _characterContext = context;
        }
        public async Task<Character> CreateAsync(Character character)
        {
            _characterContext.Add(character);
            await _characterContext.SaveChangesAsync();
            return character;
        }

        public async Task<Character> GetByIdAsync(Guid id)
        {
            return await _characterContext.Characters.Include(c => c.CharacterType)
                .SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Character>> GetCharactersAsync()
        {
            return await _characterContext.Characters.ToListAsync();
        }

        public async Task<Character> RemoveAsync(Character character)
        {
            _characterContext.Remove(character);
            await _characterContext.SaveChangesAsync();
            return character;
        }

        public async Task<Character> UpdateAsync(Character character)
        {
            _characterContext.Update(character);
            await _characterContext.SaveChangesAsync();
            return character;
        }
    }
}
