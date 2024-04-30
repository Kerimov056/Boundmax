using ParkCinema.Persistance.Exceptions;
using System.Net;

namespace Boundmax.Persistance.Exceptions;

public class PermissionException : Exception, IBaseException
{
    public int StatusCode { get; set; }

    public string CustomMessage { get; set; }

    public PermissionException(string message) : base(message)
    {
        StatusCode = (int)HttpStatusCode.NotFound;
        CustomMessage = message;
    }
}