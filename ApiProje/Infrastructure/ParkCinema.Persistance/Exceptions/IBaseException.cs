namespace ParkCinema.Persistance.Exceptions;

public interface IBaseException
{
    int StatusCode { get; } 
    string CustomMessage { get; }
}
