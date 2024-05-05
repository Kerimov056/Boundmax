using Microsoft.AspNetCore.Http;

namespace Boundmax.Application.DTOs.Blog;

public class BlogCreateImageFile
{
    public IFormFile ImageFile { get; set; }
}
