using Boundmax.Application.DTOs.Blog;

namespace Boundmax.Application.Abstraction.Services;

public interface IBlogService
{
    Task CreateAsync(CreateBlogDto createBlogDto);
    Task<GetBlogDto> GetByIdAsync(Guid Id);
    Task<List<MainGetBlogDto>> GetAllAsync();
    Task DeleteAsync(Guid Id, string AppUserId);
    Task<List<MainGetBlogDto>> SearchBlog(string? searchText);
    Task<List<MainGetBlogDto>> LastThreeBlogs(); 
}
