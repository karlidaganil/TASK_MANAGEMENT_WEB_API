using TASK_MANAGEMENT_WEB_API.Enums;

namespace TASK_MANAGEMENT_WEB_API.Dto;

public class GetTasksFilterDto
{
    public Status? Status { get; set; }
    public DateTime? DueDateFrom { get; set; }
    public DateTime? DueDateTo { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 5;
}