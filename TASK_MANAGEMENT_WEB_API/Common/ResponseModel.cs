namespace TASK_MANAGEMENT_WEB_API.Common;

public class ResponseModel<T>
{
    public bool Success { get; set; } = true;
    public T Payload { get; set; } = default!;
    public string Message { get; set; } = string.Empty;
}