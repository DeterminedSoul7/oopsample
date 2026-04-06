namespace oopsample.Shared.Domain.Model.ValueObjects;
/// <summary>
/// Represents an international physical address value object
/// </summary>
public record Address
{
    public string Street;
    public string Number;
    public string City;
    public string? StateOrRegion;
    public string PostalCode;
    public string Country;
    
    /// <summary>
    /// creates a new instance of <see cref="Address"/>
    /// </summary>
    /// <param name="street">the address street, which must not be null or blank.</param>
    /// <param name="number">the address number, which must not be null or blank.</param>
    /// <param name="city">the address city, which must not be null or blank.</param>
    /// <param name="stateOrRegion">the state or region</param>
    /// <param name="postalCode">the address postal code, which must not be null or blank.</param>
    /// <param name="country">the address country, which must not be null or blank.</param>
    /// <exception cref="ArgumentNullException">thrown when any required parameter is null or blank</exception>
    
    public Address(string street, string number, string city, string? stateOrRegion, string postalCode, string country) 
    {
        if (string.IsNullOrWhiteSpace(street)) throw new ArgumentNullException("Street cannot be null or empty");
        if (string.IsNullOrWhiteSpace(number)) throw new ArgumentNullException("Number cannot be null or empty");
        if (string.IsNullOrWhiteSpace(city)) throw new ArgumentNullException("City cannot be null or empty");
        if (string.IsNullOrWhiteSpace(postalCode)) throw new ArgumentNullException("Postal code cannot be null or empty");
        if (string.IsNullOrWhiteSpace(country)) throw new ArgumentNullException("Country cannot be null or empty");
        Street = street;
        Number = number;
        City = city;
        StateOrRegion = stateOrRegion;
        PostalCode = postalCode;
        Country = country;
    }
    
    /// <summary>
    /// Returns the string representation of the address in the format: "Street, Number, City, StateOrRegion, PostalCode, Country".
    /// </summary>
    /// <returns>string containing the address values</returns>
    public override string ToString() => $"{Street}, {Number}, {City}, {StateOrRegion}, {PostalCode}, {Country}";
}
 