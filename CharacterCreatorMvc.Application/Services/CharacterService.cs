using AutoMapper;
using CharacterCreatorMvc.Application.Characters.Commands;
using CharacterCreatorMvc.Application.Characters.Query;
using CharacterCreatorMvc.Application.DTOs;
using CharacterCreatorMvc.Application.Interfaces;
using MediatR;

namespace CharacterCreatorMvc.Application.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CharacterService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task AddAsync(CharacterDTO characterTypeDTO)
        {
            var characterCreateCommand = _mapper.Map<CharacterCreateCommand>(characterTypeDTO);
            await _mediator.Send(characterCreateCommand);
        }

        public async Task<CharacterDTO> GetCharacterByIdAsync(Guid id)
        {
            var characterByIdQuery = new GetCharacterByIdQuery(id);

            if (characterByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(characterByIdQuery);

            return _mapper.Map<CharacterDTO>(result);
        }

/*        public async Task<CharacterDTO> GetCharacterTypeAsync(Guid id)
        {
            var characterByIdQuery = new GetCharacterByIdQuery(id);

            if (characterByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(characterByIdQuery);

            return _mapper.Map<CharacterDTO>(result);
        }*/

        public async Task<IEnumerable<CharacterDTO>> GetCharactersAsync()
        {
            var characterQuery = new GetCharactersQuery();

            if (characterQuery == null)
                throw new Exception($"Entity could not be found");

            var result = await _mediator.Send(characterQuery);

            return _mapper.Map<IEnumerable<CharacterDTO>>(result);
        }

        public async Task RemoveAsync(Guid id)
        {
            var productRemoveCommand = new CharacterRemoveCommand(id);
            if (productRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(productRemoveCommand);
        }

        public async Task UpdateAsync(CharacterDTO characterTypeDTO)
        {
            var characterCreateCommand = _mapper.Map<CharacterUpdateCommand>(characterTypeDTO);
            await _mediator.Send(characterCreateCommand);
        }
    }
}