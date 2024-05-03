using Boundmax.Application.Abstraction.Services;
using Boundmax.Application.DTOs.Blog;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Boundmax.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BlogsController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogsController(IBlogService blogService)
     => _blogService = blogService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var blogs = await _blogService.GetAllAsync();
        return Ok(blogs);
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
    public async Task<IActionResult> GetSearchBlogs(string? searchText)
    {
        var byBlogs = await _blogService.SearchBlog(searchText);
        return Ok(byBlogs);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] CreateBlogDto createBlogDto)
    {
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
