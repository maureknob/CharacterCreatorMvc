using CharacterCreatorMvc.Domain.Entities;
using FluentAssertions;

namespace CharacterCreatorMvc.Domain.Tests
{
    public class CharacterUnitTest1
    {
        [Fact]
        public void CreateCharacter_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Character(Guid.NewGuid(), "Conan", "Warrior", 10, 10, "image");
            action.Should()
                .NotThrow<CharacterCreatorMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCharacter_ShortName_DomainExceptionShortName()
        {
            Action action = () => new Character(Guid.NewGuid(), "Co", "Warrior", 10, 10, "image");
            action.Should()
                .Throw<CharacterCreatorMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateCharacter_NullDescription_DomainExceptionNullDescription()
        {
            Action action = () => new Character(Guid.NewGuid(), "Mauricio", null, 10, 10, "image");
            action.Should()
                .Throw<CharacterCreatorMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
        }

        [Fact]
        public void CreateCharacter_LessThenOneHp_DomainExceptionHpInvalid()
        {
            Action action = () => new Character(Guid.NewGuid(), "Mauricio", "Warrior", 0, 10, "image");
            action.Should()
                .Throw<CharacterCreatorMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid health point. A value grater then 0 is required");
        }

        [Fact]
        public void CreateCharacter_LessThanOneDamage_DomainExceptionInvalidDamage()
        {
            Action action = () => new Character(Guid.NewGuid(), "Mauricio", "Warrior", 10, 0, "image");
            action.Should()
                .Throw<CharacterCreatorMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid demage. A value grater then 0 is required");
        }

        [Fact]
        public void CreateCharacter_LongImageName_DomainExceptionLomngImageName()
        {
            Action action = () => new Character(Guid.NewGuid(), "Mauricio", "Warrior", 10, 10, "imagedddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd");
            action.Should()
                .Throw<CharacterCreatorMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image. Image name too long");
        }

        [Fact]
        public void CreateCharacter_WithNullImageName_NoDomainsException()
        {
            Action action = () => new Character(Guid.NewGuid(), "Mauricio", "Warrior", 10, 10, null);
            action.Should()
                .NotThrow<CharacterCreatorMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCharacter_WithNullImageName_NullReferenceException()
        {
            Action action = () => new Character(Guid.NewGuid(), "Mauricio", "Warrior", 10, 10, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }
    }
}
