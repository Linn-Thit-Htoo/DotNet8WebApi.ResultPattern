using DotNet8WebApi.ResultPattern.Database;
using DotNet8WebApi.ResultPattern.Models;
using DotNet8WebApi.ResultPattern.Resources;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebApi.ResultPattern.Features.Blog;

public class DA_Blog
{
    private readonly AppDbContext _appDbContext;

    public DA_Blog(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Result<BlogListResponseModel>> GetBlogList()
    {
        try
        {
            var dataLst = await _appDbContext.Blogs.OrderByDescending(x => x.BlogId).ToListAsync();
            var lst = dataLst.Select(x => x.Change()).ToList();
            var model = new BlogListResponseModel
            {
                Blogs = lst
            };

            return Result<BlogListResponseModel>.SuccessResult(model, MessageResource.Success);
        }
        catch (Exception ex)
        {
            return Result<BlogListResponseModel>.FailureResult(ex);
        }
    }

    public async Task<Result<BlogResponseModel>> CreateBlog(BlogRequestModel requestModel)
    {
        try
        {
            await _appDbContext.Blogs.AddAsync(requestModel.Change());
            int result = await _appDbContext.SaveChangesAsync();

            return result > 0 ? Result<BlogResponseModel>.SuccessResult(MessageResource.SaveSuccess)
                : Result<BlogResponseModel>.FailureResult(MessageResource.SaveFail);
        }
        catch (Exception ex)
        {
            return Result<BlogResponseModel>.FailureResult(ex);
        }
    }

    public async Task<Result<BlogResponseModel>> UpdateBlog(BlogRequestModel requestModel, int id)
    {
        try
        {
            var item = await _appDbContext.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
            if (item is null)
                return Result<BlogResponseModel>.FailureResult(MessageResource.NotFound);

            if (!string.IsNullOrEmpty(requestModel.BlogTitle))
                item.BlogTitle = requestModel.BlogTitle;

            if (!string.IsNullOrEmpty(requestModel.BlogAuthor))
                item.BlogAuthor = requestModel.BlogAuthor;

            if (!string.IsNullOrEmpty(requestModel.BlogContent))
                item.BlogContent = requestModel.BlogContent;

            _appDbContext.Blogs.Update(item);
            int result = await _appDbContext.SaveChangesAsync();

            return result > 0 ? Result<BlogResponseModel>.SuccessResult(MessageResource.UpdateSuccess)
                : Result<BlogResponseModel>.FailureResult(MessageResource.UpdateFail);
        }
        catch (Exception ex)
        {
            return Result<BlogResponseModel>.FailureResult(ex);
        }
    }

    public async Task<Result<BlogResponseModel>> DeleteBlog(int id)
    {
        try
        {
            var item = await _appDbContext.Blogs.FindAsync(id);
            if (item is null)
                return Result<BlogResponseModel>.FailureResult(MessageResource.NotFound);

            _appDbContext.Blogs.Remove(item);
            int result = await _appDbContext.SaveChangesAsync();

            return result > 0 ? Result<BlogResponseModel>.SuccessResult(MessageResource.DeleteSuccess)
                : Result<BlogResponseModel>.FailureResult(MessageResource.DeleteFail);
        }
        catch (Exception ex)
        {
            return Result<BlogResponseModel>.FailureResult(ex);
        }
    }
}
