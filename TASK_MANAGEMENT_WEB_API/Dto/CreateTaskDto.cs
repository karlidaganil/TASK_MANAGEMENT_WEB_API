namespace TASK_MANAGEMENT_WEB_API.Dto;

public record CreateTaskDto(
    string title,
    string description,
    string status,
    DateTime dueDate
);