using CleanNet.Domain.Validation;

namespace CleanNet.Domain.Entities;

public sealed class Seller : Entity
{
    public string Name { get; private set; }

    public ICollection<Order> Orders{ get; set; }

    public Seller(string name)
    {
        ValidateDomain(name);
    }

    public Seller(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value.");
        Id = id;
        ValidateDomain(name);
    }

    public void Update(string name)
    {
        ValidateDomain(name);
    }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name.Name is required");

        DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short, minimum 3 characters");

        Name = name;
    }
}
