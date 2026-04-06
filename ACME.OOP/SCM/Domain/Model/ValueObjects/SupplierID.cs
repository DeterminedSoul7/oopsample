namespace oopsample.SCM.Domain.Model.ValueObjects;

public record SupplierID
{
    public string Identifier { get; init; }

    /// <summary>
    /// Creates a new instance of <see cref="SupplierID"/>
    /// </summary>
    /// <param name="identifier">The unique identifier for the supplier. It should not be null, empty, or whitespace.</param>
    /// <exception cref="ArgumentException">Thrown when the provided identifier is null, empty, or consists only of whitespace.</exception>
    public SupplierID(string identifier)
    {
        if (string.IsNullOrWhiteSpace(identifier))
            throw new ArgumentException("Supplier identifier should not be null or whitespace.", nameof(identifier));
        Identifier = identifier;
    }
}