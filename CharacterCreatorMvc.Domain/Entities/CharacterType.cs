using CharacterCreatorMvc.Domain.Validation;

namespace CharacterCreatorMvc.Domain.Entities
{
    public sealed class CharacterType : Entity
    {
        public CharacterType(string name)
        {
            ValidateDomain(name);
        }

        public CharacterType(Guid id, string name)
        {
            DomainExceptionValidation.When(id == Guid.Empty, "Invalid Id");
            Id = id;

            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<Character> Characters { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            Name = name;
        }
    }
}
