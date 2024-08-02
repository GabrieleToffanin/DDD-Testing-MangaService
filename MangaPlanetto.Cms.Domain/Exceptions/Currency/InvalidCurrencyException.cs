namespace MangaPlanetto.Cms.Domain.Exceptions.Currency;

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
}
