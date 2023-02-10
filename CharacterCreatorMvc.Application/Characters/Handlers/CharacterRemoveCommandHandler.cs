using CharacterCreatorMvc.Application.Characters.Commands;
using CharacterCreatorMvc.Domain.Entities;
using CharacterCreatorMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterCreatorMvc.Application.Characters.Handlers
{
    public class CharacterRemoveCommandHandler : IRequestHandler<CharacterRemoveCommand, Character>
    {
        private readonly ICharacterRepository _characterRepository;
        public CharacterRemoveCommandHandler(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }
        public async Task<Character> Handle(CharacterRemoveCommand request, CancellationToken cancellationToken)
        {
            var character = await _characterRepository.GetByIdAsync(request.Id);

            if (character == null)
            {
                throw new ApplicationException($"Entity could not be found");
            }
            else
            {
                return await _characterRepository.RemoveAsync(character);
            }
        }
    }
}
