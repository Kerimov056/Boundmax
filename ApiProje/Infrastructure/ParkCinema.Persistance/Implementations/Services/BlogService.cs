using AutoMapper;
using Boundmax.Application.Abstraction.Repositories.IEntityRepository;
using Boundmax.Application.Abstraction.Services;
using Boundmax.Application.DTOs.Blog;
using Boundmax.Domain.Entities;
using Boundmax.Persistance.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ParkCinema.Persistance.Context;
using ParkCinema.Persistance.Exceptions;

namespace Boundmax.Persistance.Implementations.Services;

public class BlogService : IBlogService
{
    private readonly AppDbContext _appDbcontext;
    private readonly IBlogReadRepository _blogReadRepository;
    private readonly IBlogWriteRepository _blogWriteRepository;
    private readonly IMapper _mapper;

    public BlogService(AppDbContext appDbcontext,
                       IBlogReadRepository blogReadRepository,
                       IBlogWriteRepository blogWriteRepository,
                       IMapper mapper)
    {
        _appDbcontext = appDbcontext;
        _blogReadRepository = blogReadRepository;
        _blogWriteRepository = blogWriteRepository;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateBlogDto createBlogDto)
    {
        if (await _appDbcontext.Users.FirstOrDefaultAsync(x => x.Id == createBlogDto.AdminId) is null)
            throw new PermissionException("Not Access");
        var newBlog = _mapper.Map<Blogs>(createBlogDto);

        await _blogWriteRepository.AddAsync(newBlog);
        await _blogWriteRepository.SaveChangeAsync();

        var toAuthorMapper = _mapper.Map<List<Authors>>(createBlogDto.CreateAuthorDtos);
        toAuthorMapper.ForEach(x => x.BlogId = newBlog.Id);
        await _appDbcontext.Authors.AddRangeAsync(toAuthorMapper);

        var toReferencesMapper = _mapper.Map<List<References>>(createBlogDto.CreateReferenceDtos);
        toReferencesMapper.ForEach(x => x.BlogId = newBlog.Id);
        await _appDbcontext.References.AddRangeAsync(toReferencesMapper);

        //var toBlogDescriptionsMapper = _mapper.Map<List<BlogDescriptions>>(createBlogDto.CreateBlogDescriptionDtos);
        //toBlogDescriptionsMapper.ForEach(x => x.BlogId = newBlog.Id);
        //await _appDbcontext.BlogDescriptions.AddRangeAsync(toBlogDescriptionsMapper);

        await _blogWriteRepository.SaveChangeAsync();
    }

    public async Task DeleteAsync(Guid Id, string AppUserId)
    {
        var blog = await _blogReadRepository.GetByIdAsync(Id);
        if (blog is null) throw new NotFoundException("Not Found Blog");

        _blogWriteRepository.Remove(blog);
        await _blogWriteRepository.SaveChangeAsync();
    }

    public async Task<List<MainGetBlogDto>> GetAllAsync()
    {
        var allBlogs = await _blogReadRepository.GetAll()
                            .OrderByDescending(x => x.CreatedDate)
                            .Select(x => new MainGetBlogDto
                            {
                                Id = x.Id,
                                Title = x.Title,
                                //MainImageUrl = x.MainImageUrl,
                                SourceLanguage = x.SourceLanguage,
                                BlogAuthorName = x.BlogAuthorName,
                                CreatedDate = x.CreatedDate
                            }).ToListAsync();

        return allBlogs;
    }


    public async Task<GetBlogDto> GetByIdAsync(Guid Id)
    {
        var blog = await _blogReadRepository.GetAll()
                                            .Include(x => x.Authors)
                                            .Include(x => x.References)
                                            //.Include(x=>x.BlogDescriptions)
                                            .FirstOrDefaultAsync(x => x.Id == Id);
        if (blog is null) throw new NotFoundException("Not Found Blog");

        return _mapper.Map<GetBlogDto>(blog);
    }

    public async Task<List<GetBlogDto>> SearchBlog(string searchText)
    {
        if (string.IsNullOrEmpty(searchText))
            return null;

        var blogs = await _blogReadRepository.GetAll()
                                             .Include(x => x.Authors)
                                             .Where(x => x.Title.Contains(searchText) ||
                                                         x.SourceLanguage.Contains(searchText) ||
                                                         x.Text.Contains(searchText) ||
                                                         x.Authors.Any(a => a.Fullname.Contains(searchText)))
                                             .ToListAsync();

        return _mapper.Map<List<GetBlogDto>>(blogs);
    }

}
