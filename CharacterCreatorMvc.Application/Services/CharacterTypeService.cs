using AutoMapper;
using CharacterCreatorMvc.Application.DTOs;
using CharacterCreatorMvc.Application.Interfaces;
using CharacterCreatorMvc.Domain.Entities;
using CharacterCreatorMvc.Domain.Interfaces;

namespace CharacterCreatorMvc.Application.Services
{
    public class CharacterTypeService : ICharacterTypeService
    {
        private ICharacterTypeRepository _characterTypeRepository;
        private readonly IMapper _mapper;

        public CharacterTypeService(ICharacterTypeRepository characterRepository, IMapper mapper)
        {
            _characterTypeRepository = characterRepository;
            _mapper = mapper;
        }

        public async Task AddAsync(CharacterTypeDTO characterTypeDTO)
        {
            characterTypeDTO.Id = Guid.NewGuid();
            var characterTypeEntity = _mapper.Map<CharacterType>(characterTypeDTO);
            await _characterTypeRepository.CreateAsync(characterTypeEntity);
        }

        public async Task<CharacterTypeDTO> GetCharacterTypeByIdAsync(Guid id)
        {
            var characterTypeEntity = await _characterTypeRepository.GetByIdAsync(id);
            return _mapper.Map<CharacterTypeDTO>(characterTypeEntity);
        }

        public async Task<IEnumerable<CharacterTypeDTO>> GetCharacterTypesAsync()
        {
            var characterTypesEntity = await _characterTypeRepository.GetCharacterTypesAsync();
            return _mapper.Map<IEnumerable<CharacterTypeDTO>>(characterTypesEntity);
        }

        public async Task RemoveAsync(Guid id)
        {
            var characterTypeEntity = await _characterTypeRepository.GetByIdAsync(id);
            await _characterTypeRepository.RemoveAsync(characterTypeEntity);
        }

        public async Task UpdateAsync(CharacterTypeDTO characterTypeDTO)
        {
            var characterTypeEntity = _mapper.Map<CharacterType>(characterTypeDTO);
            await _characterTypeRepository.UpdateAsync(characterTypeEntity);
        }
    }
}
