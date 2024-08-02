using MangaPlanetto.Cms.Domain.Exceptions.Currency;

namespace MangaPlanetto.Cms.Domain.ValueObjects;

public sealed record Price
{
    public Currency CurrencyValue { get; private set; }
    public decimal Value { get; private set; }

    public Price(string currency, decimal value)
    {
        this.CurrencyValue = this.GetCurrencyFromString(currency);
        this.Value = value;
    }

    public static Price CreatePrice(
        string currency,
        decimal value)
    {
        return new Price(currency, value);
    }

    private Currency GetCurrencyFromString(string currency) => currency switch
    {
        "USD" => Currency.USD,
        _ => throw new InvalidCurrencyException(currency)
    };

    public enum Currency
    {
        USD
    }
}
