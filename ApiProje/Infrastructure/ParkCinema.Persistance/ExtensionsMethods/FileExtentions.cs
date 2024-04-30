using Microsoft.AspNetCore.Http;

namespace ParkCinema.Persistance.ExtensionsMethods;

public static class FileExtentions
{
    public static async Task<byte[]> GetBytes(this IFormFile formFile)
    {
        await using var memoryStream = new MemoryStream();
        await formFile.CopyToAsync(memoryStream);
        return memoryStream.ToArray();
    }
}
