namespace TASK_MANAGEMENT_WEB_API.Dto;

public record GetTaskDto(
    int id,
    string title,
    string description,
    string status,
    DateTime dueDate
);