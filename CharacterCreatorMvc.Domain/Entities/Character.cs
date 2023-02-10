using CharacterCreatorMvc.Domain.Validation;

namespace CharacterCreatorMvc.Domain.Entities
{

    public sealed class Character : Entity
    {
        public string Description { get; private set; }
        public int HealthPoints { get; private set; }
        public int Damage { get; private set; }
        public string Image { get; private set; }

        public Character(string name, string description, int healthPoints, int damage, string image)
        {
            ValidateDomain(name, description, healthPoints, damage, image);
        }

        public Character(Guid id, string name, string description, int healthPoints, int damage, string image)
        {
            DomainExceptionValidation.When(id == Guid.Empty, "Invalid Id");
            Id = id;

            ValidateDomain(name, description, healthPoints, damage, image);
        }

        public void Update(string name, string description, int hp, int damage, string image, Guid characterType)
        {
            ValidateDomain(name, description, hp, damage, image);
            CharacterTypeId = characterType;
        }

        private void ValidateDomain(string name, string description, int healthPoints, int damage, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required");

            DomainExceptionValidation.When(healthPoints < 1,
                "Invalid health point. A value grater then 0 is required");

            DomainExceptionValidation.When(damage < 1,
                "Invalid demage. A value grater then 0 is required");

            DomainExceptionValidation.When(image?.Length > 250,
                "Invalid image. Image name too long");

            Name = name;
            Description = description;
            HealthPoints = healthPoints;
            Damage = damage;
            Image = image;
        }

        public Guid CharacterTypeId { get; set; }
        public CharacterType CharacterType { get; set; }
    }
}
