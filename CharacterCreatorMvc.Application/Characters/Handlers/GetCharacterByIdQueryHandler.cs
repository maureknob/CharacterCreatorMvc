using CharacterCreatorMvc.Application.Characters.Query;
using CharacterCreatorMvc.Domain.Entities;
using CharacterCreatorMvc.Domain.Interfaces;
using MediatR;

namespace CharacterCreatorMvc.Application.Characters.Handlers
{
    public class GetCharacterByIdQueryHandler : IRequestHandler<GetCharacterByIdQuery, Character>
    {
        private readonly ICharacterRepository _characterRepository;
        public GetCharacterByIdQueryHandler(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }
        public async Task<Character> Handle(GetCharacterByIdQuery request, CancellationToken cancellationToken)
        {
            return await _characterRepository.GetByIdAsync(request.Id);
        }
    }
}
