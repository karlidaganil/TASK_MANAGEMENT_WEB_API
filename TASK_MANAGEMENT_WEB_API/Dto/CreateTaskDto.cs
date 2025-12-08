using TASK_MANAGEMENT_WEB_API.Enums;

namespace TASK_MANAGEMENT_WEB_API.Dto;

public record CreateTaskDto(
    string title,
    string description,
    Status status,
    DateTime dueDate
);