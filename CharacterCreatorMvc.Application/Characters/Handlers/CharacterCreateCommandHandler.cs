using CharacterCreatorMvc.Application.Characters.Commands;
using CharacterCreatorMvc.Domain.Entities;
using CharacterCreatorMvc.Domain.Interfaces;
using MediatR;

namespace CharacterCreatorMvc.Application.Characters.Handlers
{
    public class CharacterCreateCommandHandler : IRequestHandler<CharacterCreateCommand, Character>
    {
        private readonly ICharacterRepository _characterRepository;
        public CharacterCreateCommandHandler(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        public async Task<Character> Handle(CharacterCreateCommand request, CancellationToken cancellationToken)
        {
            var character = new Character(request.Id = Guid.NewGuid(), request.Name, request.Description,
                request.HealthPoints, request.Damage, request.Image);

            if (character == null)
            {
                throw new ApplicationException($"Error creating entity");
            }
            else
            {
                character.CharacterTypeId = request.CharacterTypeId;
                return await _characterRepository.CreateAsync(character);
            }
        }
    }
}
