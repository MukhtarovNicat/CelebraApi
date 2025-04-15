using Microsoft.AspNetCore.Http;

namespace Celebra.Business.Exceptions.Common;

public class NotFoundException<T> : Exception , IBaseException
{
    public int StatusCode => StatusCodes.Status404NotFound;

    public string ErrorMessage { get; }

    public NotFoundException() : base()
    {
        ErrorMessage = $"{typeof(T).Name} mövcud deyil.";
    }

    public NotFoundException(string? message) : base(message)
    {
        ErrorMessage = message;
    }
}