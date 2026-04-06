namespace oopsample.Shared.Domain.Model.ValueObjects;

// XML Docs
/// <summary>
/// Represents a monetary value with an amount and a currency.
/// This is a value object, meaning it is inmutable and equality is based on its properties rather than identity.
/// </summary>
public record Money
{
    public decimal Amount { get; init; }
    public string Currency { get; init; }

    /// <summary>
    /// Creates a new instance of <see cref="Money"/>
    /// </summary>
    /// <param name="amount">The monetary amount</param>
    /// <param name="currency">The currency</param>
    /// <exception cref="ArgumentException">Thrown when the currency is not a valid 3 leter ISO code</exception>
    public Money(decimal amount, string currency)
    {
        if (string.IsNullOrWhiteSpace(currency)|| currency.Length != 3)
            throw new ArgumentException("Currency must be a 3-letter code", nameof(currency));
        Amount = amount;
        Currency = currency;
    }
    
    /// <summary>
    /// Returns a string representation of the money, combining the amount and currency.
    /// </summary>
    /// <returns>A string in the format "Amount Currency"</returns>
    public override string ToString() => $"{Amount} {Currency}"; //Cadena con template

    /// <summary>
    /// Adds two <see cref="Money"/>
    /// </summary>
    /// <param name="other">The other <see cref="Money"/> to add. Must have the same currency.</param>
    /// <returns>A new <see cref="Money"/> instance with the combined amount if the currencies match; otherwise, throws an exception.</returns>
    /// <exception cref="InvalidOperationException">Thrown when the currencies do not match.</exception>
    public Money Add(Money? other)
    {
        if (other != null && Currency != other.Currency)
            throw new ArgumentException("Cannot add money with different currencies");
        return other == null ? this : new Money(Amount + other.Amount, Currency);
    }
    
    /// <summary>
    /// Multiplies the monetary value by a factor
    /// </summary>
    /// <param name="multiplier">The factor to multiply the amount by</param>
    /// 
    /// <returns></returns>
    public Money Multiply(int multiplier) => new (Amount * multiplier, Currency);
    // El compilador puede asumir el tipo de retorno con el constructor
}