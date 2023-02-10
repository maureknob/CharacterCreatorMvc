namespace CharacterCreatorMvc.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
    }
}