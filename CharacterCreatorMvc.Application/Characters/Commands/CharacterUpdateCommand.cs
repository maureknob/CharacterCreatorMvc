namespace CharacterCreatorMvc.Application.Characters.Commands
{
    public class CharacterUpdateCommand : CharacterCommand
    {
        public Guid Id { get; set; }
    }
}
