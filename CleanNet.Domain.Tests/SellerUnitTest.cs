using CleanNet.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanNet.Domain.Tests;

public class SellerUnitTest
{
    [Fact(DisplayName = "Create Seller With Valid State")]
    public void CreateSeller_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Seller(1, "Seller Name");
        action.Should()
             .NotThrow<CleanNet.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CreateSeller_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Seller(-1, "Seller Name ");
        action.Should()
            .Throw<CleanNet.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value.");
    }

    [Fact]
    public void CreateSeller_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Seller(1, "Se");
        action.Should()
            .Throw<CleanNet.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characters");
    }

    [Fact]
    public void CreateSeller_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Seller(1, "");
        action.Should()
            .Throw<CleanNet.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name.Name is required");
    }

    [Fact]
    public void CreateSeller_WithNullNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new Seller(1, null);
        action.Should()
            .Throw<CleanNet.Domain.Validation.DomainExceptionValidation>();
    }
}
