using DotNet8WebApi.ResultPattern.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8WebApi.ResultPattern.Features.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BL_Blog _bL_Blog;

        public BlogController(BL_Blog bL_Blog)
        {
            _bL_Blog = bL_Blog;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            try
            {
                var result = await _bL_Blog.GetBlogList();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, Result<BlogListResponseModel>.FailureResult(ex));
            }
        }
    }
}
