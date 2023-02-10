using CharacterCreatorMvc.Domain.Entities;
using FluentAssertions;

namespace CharacterCreatorMvc.Domain.Tests
{
    public class CharacterTypeUnitTest1
    {
        [Fact]
        public void CreateCharacterType_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new CharacterType(Guid.NewGuid(), "Guerreiro");
            action.Should()
                .NotThrow<CharacterCreatorMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCharacterType_EmptyGuid_DomainExceptionInvalid()
        {
            Action action = () => new CharacterType(Guid.Empty, "Guerreiro");
            action.Should()
                .Throw<CharacterCreatorMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id");
        }

        [Fact]
        public void CreateCharacterType_ShortName_DomainExceptionShortName()
        {
            Action action = () => new CharacterType(Guid.NewGuid(), "Gu");
            action.Should()
                .Throw<CharacterCreatorMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateCharacterType_MissingValueNAme_DomainExceptionRequiredName()
        {
            Action action = () => new CharacterType(Guid.NewGuid(), "");
            action.Should()
                .Throw<CharacterCreatorMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact]
        public void CreateCharacterType_WithNullValue_DomainExceptionRequiredName()
        {
            Action action = () => new CharacterType(Guid.NewGuid(), null);
            action.Should()
                .Throw<CharacterCreatorMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }
    }
}