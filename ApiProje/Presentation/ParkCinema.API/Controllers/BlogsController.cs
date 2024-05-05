using Boundmax.Application.Abstraction.Services;
using Boundmax.Application.DTOs.Blog;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Boundmax.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController : ControllerBase
{
    private readonly IBlogService _blogService;
    private readonly IConfiguration _configuration;
    private readonly StorageClient _storageClient;

    public BlogsController(IBlogService blogService,
                           IConfiguration configuration,
                           StorageClient storageClient)
    {
        _blogService = blogService;
        _configuration = configuration;
        _storageClient = storageClient;
    }


    //[HttpGet]
    //public async Task<IActionResult> GetAll()
    //{
    //    var blogs = await _blogService.GetAllAsync();
    //    return Ok(blogs);
    //}
    [HttpGet("[action]")]
    public async Task<IActionResult> TotalBlogPage(int pageSize = 12)
    {
        return Ok(await _blogService.GetTotalPages(pageSize));
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> ThreeLastBlogs()
    {
        var blogs = await _blogService.LastThreeBlogs();
        return Ok(blogs);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetById(Guid Id)
    {
        var byBlog = await _blogService.GetByIdAsync(Id);
        return Ok(byBlog);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetSearchBlogs(string? searchText, int pageNumber = 1, int pageSize = 12)
    {
        var byBlogs = await _blogService.SearchBlog(searchText, pageNumber, pageSize);
        return Ok(byBlogs);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> CreateMainImageUrl([FromForm]BlogCreateImageFile blogCreateImageFile)
    {
        if (blogCreateImageFile.ImageFile == null || blogCreateImageFile.ImageFile.Length == 0)
            return BadRequest("Dosya Empty.");

        string ApiKey = _configuration["GoogleCloud:ApiKey"];
        var credential = GoogleCredential.FromFile(ApiKey);

        var client = StorageClient.Create(credential);
        var imageUrl = string.Empty;

        using (var memoryStream = new MemoryStream())
        {
            await blogCreateImageFile.ImageFile.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            var objectName = $"Images/{Guid.NewGuid()}_{blogCreateImageFile.ImageFile.FileName}";
            var bucketName = "boundmax";

            await client.UploadObjectAsync(bucketName, objectName, null, memoryStream);
            var url = $"https://storage.googleapis.com/{bucketName}/{objectName}";

            imageUrl = url;
        }

        return Ok(imageUrl);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] CreateBlogDto createBlogDto)
    {
        //createBlogDto.MainImageUrl = blogCreateImageFile.ImageFile.Name;
        await _blogService.CreateAsync(createBlogDto);
        return StatusCode((int)HttpStatusCode.Created);
    }

    [HttpDelete("[action]")]
    public async Task<IActionResult> Remove(Guid Id, string AppUserId)
    {
        await _blogService.DeleteAsync(Id, AppUserId);
        return Ok();
    }
}
