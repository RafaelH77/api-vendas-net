 using CleanNet.Domain.Validation;

namespace CleanNet.Domain.Entities;

public sealed class Order : Entity
{
    public DateTime Date { get; private set; }
    public decimal Amount { get; private set; }
    public decimal Comission { get; private set; }
    public string Observation { get; private set; }
    public int SellerId { get; set; }
    public Seller Seller { get; set; }

    public Order(DateTime date, decimal amount, decimal comission, string observation)
    {
        ValidateDomain(date, amount, comission, observation);
    }

    public Order(int id, DateTime date, decimal amount, decimal comission, string observation)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(date, amount, comission, observation);
    }

    public void Update(DateTime date, decimal amount, decimal comission, string observation, int sellerId)
    {
        ValidateDomain(date, amount, comission, observation);
        SellerId = sellerId;
    }

    private void ValidateDomain(DateTime date, decimal amount, decimal comission, string observation)
    {
        DomainExceptionValidation.When(amount < 0, "Invalid order value");

        DomainExceptionValidation.When(comission < 0, "Invalid comission, negative value");

        Date = date;
        Amount = amount;
        Comission = comission;
        Observation = observation;
    }
}
