using oopsample.Procurement.Domain.Model.ValueObjects;
using oopsample.Shared.Domain.Model.ValueObjects;

namespace oopsample.Procurement.Domain.Model.Aggregates;

    /// <summary>
    /// Represents a purchase order item aggregate in the Procurement bounded context.
    /// Encapsulates the details of a single item in a purchase order, including the product id, quantity, and unit price.
    /// </summary>
public class PurchaseOrderItem
{
    public ProductID ProductID { get; }
    
    public int Quantity { get; }
    
    public Money UnitPrice { get; }
    /// <summary>
    /// Creates a new instance if <see cref="PurchaseOrderItem"/>
    /// </summary>
    /// <param name="productID">The <see cref="ProductID"/> identifier</param>
    /// <param name="quantity">The product quantity to purchase.</param>
    /// <param name="unitPrice">The unit price for the product.</param>
    /// <exception cref="ArgumentNullException">Thrown when a required attribute is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when a numeric attribute is out of the expected range.</exception>
    internal PurchaseOrderItem(ProductID productID, int quantity, Money unitPrice)
    {
        ProductID = productID ?? throw new ArgumentNullException(nameof(productID));
        Quantity = quantity > 0 ? quantity : throw new ArgumentOutOfRangeException(nameof(quantity));
        UnitPrice = unitPrice ?? throw new ArgumentNullException(nameof(unitPrice));
    }
    /// <summary>
    /// Calculates the total price of the item.
    /// </summary>
    /// <returns> The toal price</returns>
    public Money CalculateTotal()=>UnitPrice.Multiply(Quantity);
}