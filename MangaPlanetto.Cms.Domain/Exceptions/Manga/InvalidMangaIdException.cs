using System.Runtime.CompilerServices;

namespace MangaPlanetto.Cms.Domain.Exceptions.Manga;

public sealed class InvalidMangaIdException : Exception
{
    public InvalidMangaIdException()
    {

    }

    public InvalidMangaIdException(string message) : base(message)
    {
    }

    public InvalidMangaIdException(string message, Exception innerException) : base(message, innerException)
    {
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Guid ThrowWhenInvalid()
    {
        throw new InvalidMangaIdException();
    }
}
