namespace TASK_MANAGEMENT_WEB_API.Common;

public class PagedResponseModel<T>
{
    public bool Success { get; set; } = true;
    public T Payload { get; set; } = default!;
    public string Message { get; set; } = string.Empty;
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
}