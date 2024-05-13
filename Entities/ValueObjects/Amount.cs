namespace NexusModuleTemplate.Entities.ValueObjects;

public sealed record Amount
{
    public string Currency { get; private set; } = string.Empty;
    public decimal Value { get; private set; }

    private Amount(string currency, decimal value)
    {
        Currency = currency;
        Value = value;
    }

    public static Amount Create(string currency, decimal value)
    {
        return new Amount(currency, value);
    }

    public static Amount Empty()
    {
        return new Amount(string.Empty, 0);
    }
}
