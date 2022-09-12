using CleanNet.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace CleanNet.Domain.Tests;

public class OrderUnitTest
{
    [Fact]
    public void CreateOrder_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Order(1, DateTime.Now, 100, 10, "Teste de observação");
        action.Should()
            .NotThrow<CleanNet.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void CreateOrder_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Order(-1, DateTime.Now, 100, 10, "Teste de observação");

        action.Should().Throw<CleanNet.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value.");
    }

    [Fact]
    public void CreateOrder_InvalidAmountValue_DomainException()
    {
        Action action = () => new Order(1, DateTime.Now, -1, 10, "Teste de observação");
        action.Should().Throw<CleanNet.Domain.Validation.DomainExceptionValidation>()
             .WithMessage("Invalid order value");
    }

    [Theory]
    [InlineData(-5)]
    public void CreateOrder_InvalidComissionValue_ExceptionDomainNegativeValue(decimal value)
    {
        Action action = () => new Order(1, DateTime.Now, 10, value, "Teste de observação");
        action.Should().Throw<CleanNet.Domain.Validation.DomainExceptionValidation>()
               .WithMessage("Invalid comission, negative value");
    }

}
