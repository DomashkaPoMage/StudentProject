namespace StudentProject.Web.Domain;

public static class OrderCalculator
{
    public static decimal CalculateTotal(decimal price, int quantity)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(price);
        ArgumentOutOfRangeException.ThrowIfNegative(quantity);

        return price * quantity;
    }
}
