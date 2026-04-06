namespace oopsample.Procurement.Domain.Model.ValueObjects;

/// <summary>
/// Represents a product identifier in the procurement bounded context. This value object encapsulates the unique identifier for a product, ensuring that it is valid and cannot be an empty GUID.
/// It provides a factory method to create new instances with a new GUID and overrides the ToString method for easy representation..
/// </summary>
public record ProductID
{
    public Guid Id { get; init; }
    
    /// <summary>
    /// Creates a new instance of <see cref="ProductID"/>
    /// </summary>
    /// <param name="id">The unique identifier for the product. Must not be an empty GUID.</param>
    /// <exception cref="ArgumentException">Thrown when the provided id is an empty GUID</exception>
    public ProductID(Guid id)
    {
        if (id == Guid.Empty)
            throw new ArgumentException($"{nameof(id)} cannot be an empty guid");
        Id = id;
    }
    /// <summary>
    /// Creates a new instance of <see cref="ProductID"/> containing a GUID value.
    /// </summary>
    /// <returns>A new instance of <see cref="ProductID"/> with a new GUID value.</returns>
    public static ProductID New() => new(Guid.NewGuid());
    /// <summary>
    /// Returns a string representation of the product identifier.
    /// </summary>
    /// <returns>A string representation of the product identifier.</returns>
    public override string ToString() => Id.ToString();
}