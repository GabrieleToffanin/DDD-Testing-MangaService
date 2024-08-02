using System.Runtime.CompilerServices;
using static MangaPlanetto.Cms.Domain.ValueObjects.Price;

namespace MangaPlanetto.Cms.Domain.Exceptions.Price;

public class InvalidCurrencyException : Exception
{
    public InvalidCurrencyException()
    {
    }

    public InvalidCurrencyException(string currency)
        : base($"Invalid currency: {currency}")
    {
    }

    public InvalidCurrencyException(string currency, Exception innerException)
        : base($"Invalid currency: {currency}", innerException)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Currency ThrowWhenUnknownCurrency(string currency)
    {
        throw new InvalidCurrencyException(currency);
    }
}
