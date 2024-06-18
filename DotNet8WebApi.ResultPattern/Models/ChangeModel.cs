namespace DotNet8WebApi.ResultPattern.Models
{
    public static class ChangeModel
    {
        public static BlogModel Change(this Tbl_Blog dataModel)
        {
            return new BlogModel
            {
                BlogId = dataModel.BlogId,
                BlogTitle = dataModel.BlogTitle,
                BlogAuthor = dataModel.BlogAuthor,
                BlogContent = dataModel.BlogContent
            };
        }
    }
}
