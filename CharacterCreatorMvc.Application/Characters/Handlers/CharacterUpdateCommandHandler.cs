using CharacterCreatorMvc.Application.Characters.Commands;
using CharacterCreatorMvc.Domain.Entities;
using CharacterCreatorMvc.Domain.Interfaces;
using MediatR;

namespace CharacterCreatorMvc.Application.Characters.Handlers
{
    public class CharacterUpdateCommandHandler : IRequestHandler<CharacterUpdateCommand, Character>
    {
        private readonly ICharacterRepository _characterRepository;
        public CharacterUpdateCommandHandler(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository ??
                throw new ArgumentNullException(nameof(characterRepository));
        }

        public async Task<Character> Handle(CharacterUpdateCommand request, CancellationToken cancellationToken)
        {
            var character = await _characterRepository.GetByIdAsync(request.Id);

            if (character == null)
            {
                throw new ApplicationException($"Entity could not be found");
            }
            else
            {
                character.Update(request.Name, request.Description,
                        request.HealthPoints, request.Damage, request.Image, request.CharacterTypeId);
                return await _characterRepository.UpdateAsync(character);
            }
        }
    }
}
