using DotNet8WebApi.ResultPattern.Models;

namespace DotNet8WebApi.ResultPattern.Features.Blog
{
    public class BL_Blog
    {
        private readonly DA_Blog _dA_Blog;

        public BL_Blog(DA_Blog dA_Blog)
        {
            _dA_Blog = dA_Blog;
        }

        public async Task<Result<BlogListResponseModel>> GetBlogList()
        {
            return await _dA_Blog.GetBlogList();
        }

        public async Task<Result<BlogResponseModel>> CreateBlog(BlogRequestModel requestModel)
        {
            return await _dA_Blog.CreateBlog(requestModel);
        }

        public async Task<Result<BlogResponseModel>> UpdateBlog(BlogRequestModel requestModel, int id)
        {
            return await _dA_Blog.UpdateBlog(requestModel, id);
        }
    }
}
