using Azure.Core;
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

        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromBody] BlogRequestModel requestModel)
        {
            try
            {
                var result = requestModel.IsValid();
                if (!result.Success)
                    return BadRequest(result);

                result = await _bL_Blog.CreateBlog(requestModel);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, Result<BlogResponseModel>.FailureResult(ex));
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBlog([FromBody] BlogRequestModel requestModel, int id)
        {
            try
            {
                var result = requestModel.IsValid(id);
                if (!result.Success)
                    return BadRequest(result);

                result = await _bL_Blog.UpdateBlog(requestModel, id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, Result<BlogResponseModel>.FailureResult(ex));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            try
            {
                var result = await _bL_Blog.DeleteBlog(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, Result<BlogResponseModel>.FailureResult(ex));
            }
        }
    }
}
