namespace DotNet8WebApi.ResultPattern.Resources;

public class MessageResource
{
    public static string Success { get; } = "Success";
    public static string Fail { get; } = "Fail";
    public static string SaveSuccess { get; } = "Successfully Save.";
    public static string SaveFail { get; } = "Fail To Save.";
    public static string NotFound { get; } = "No Data Found";
    public static string UpdateSuccess { get; } = "Successfully Update.";
    public static string UpdateFail { get; } = "Fail To Update.";
    public static string DeleteSuccess { get; } = "Successfully Delete.";
    public static string DeleteFail { get; } = "Fail To Delete.";
    public static string Duplicate { get; } = "Duplicate Data.";
}
