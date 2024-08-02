using System.Runtime.CompilerServices;

namespace MangaPlanetto.Cms.Domain.Exceptions.Price;
public class InvalidPriceException : Exception
{
    public InvalidPriceException()
    {
    }

    public InvalidPriceException(string message)
        : base(message)
    {
    }

    public InvalidPriceException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void ThrowIfLessThanZero(
        decimal price)
    {
        if (price is < 0)
            throw new InvalidPriceException("Price cannot be negative.");
    }
}
