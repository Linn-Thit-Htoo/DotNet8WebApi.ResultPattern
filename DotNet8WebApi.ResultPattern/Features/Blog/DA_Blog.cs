using DotNet8WebApi.ResultPattern.Database;
using DotNet8WebApi.ResultPattern.Models;
using DotNet8WebApi.ResultPattern.Resources;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebApi.ResultPattern.Features.Blog
{
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
    }
}
