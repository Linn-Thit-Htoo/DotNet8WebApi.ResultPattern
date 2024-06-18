namespace DotNet8WebApi.ResultPattern.Models;

public class BlogRequestModel
{
    public string? BlogTitle { get; set; }
    public string? BlogAuthor { get; set; }
    public string? BlogContent { get; set; }

    public Result<BlogResponseModel> IsValid()
    {
        if (string.IsNullOrEmpty(BlogTitle))
            return Result<BlogResponseModel>.FailureResult("Blog Title cannot be empty.");

        if (string.IsNullOrEmpty(BlogAuthor))
            return Result<BlogResponseModel>.FailureResult("Blog Author cannot be empty.");

        if (string.IsNullOrEmpty(BlogContent))
            return Result<BlogResponseModel>.FailureResult("Blog Content cannot be empty.");

        return Result<BlogResponseModel>.SuccessResult();
    }

    public Result<BlogResponseModel> IsValid(int id)
    {
        if (id <= 0)
            return Result<BlogResponseModel>.FailureResult("Blog Id is invalid.");

        return Result<BlogResponseModel>.SuccessResult();
    }
}
